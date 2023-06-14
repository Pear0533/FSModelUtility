using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.Zip;
using SearchOption = System.IO.SearchOption;

namespace FSModelUtility;

public partial class FSModelUtility : Form
{
    private const string archiveModelPartKey = "Archive Model Part";
    private const string replaceModelPartKey = "Replace Model Part";
    private const string replaceStatusKey = "Status";
    private const string version = "1.2";
    private const string modelsFolderPathKey = "ModelsFolderPath";
    private const string modelArchivesFolderPathKey = "ModelArchivesFolderPath";
    private static string modelsFolderPath = "";
    private static string modelArchivesFolderPath = "";
    private static string[] modelArchiveFilePaths = Array.Empty<string>();
    private static string[] modelFilePaths = Array.Empty<string>();
    private static readonly List<ModelArchive> modelArchives = new();
    private static readonly List<Model> models = new();
    private static readonly string appRootPath = Path.GetDirectoryName(Application.ExecutablePath) ?? "";
    private static readonly string modelReplaceLogPath = $"{appRootPath}\\model_replace_log.json";
    private static readonly string gamesDatabasePath = $"{appRootPath}\\games_database.json";
    private static readonly string csvsFolderPath = $"{appRootPath}\\CSVs";
    private static JObject modelReplaceLog = new();
    private static JObject gamesDatabase = GetDefaultGamesDatabase();

    public FSModelUtility()
    {
        InitializeComponent();
        CenterToScreen();
        SetVersionString();
        ReadGamesDatabase();
        PopulateGameTabs();
    }

    private void PopulateGameTabs()
    {
        gameTabs.TabPages.Clear();
        foreach (JProperty game in gamesDatabase.Properties())
            gameTabs.TabPages.Add(game.Name);
    }

    private static JObject GetDefaultGamesDatabase()
    {
        JObject paths = new()
        {
            { "ModelsFolderPath", "" },
            { "ModelArchivesFolderPath", "" }
        };
        JObject database = new()
        {
            { "ELDEN RING", paths },
            { "DARK SOULS I", paths },
            { "DARK SOULS II", paths },
            { "DARK SOULS III", paths }
        };
        return database;
    }

    private static void ReadGamesDatabase()
    {
        try
        {
            gamesDatabase = JObject.Parse(File.ReadAllText(gamesDatabasePath));
        }
        catch
        {
            WriteGamesDatabase();
        }
    }

    private static void WriteGamesDatabase()
    {
        File.WriteAllText(gamesDatabasePath, JsonConvert.SerializeObject(gamesDatabase, Formatting.Indented));
    }

    private void SetVersionString()
    {
        versionNumberLabel.Text += $@" {version}";
    }

    private static void ReadModelReplaceLog()
    {
        try
        {
            modelReplaceLog = JObject.Parse(File.ReadAllText(modelReplaceLogPath));
        }
        catch
        {
            modelReplaceLog = new JObject();
        }
    }

    private static void WriteModelReplaceLog()
    {
        string modelReplaceLogStr = JsonConvert.SerializeObject(modelReplaceLog, Formatting.Indented);
        File.WriteAllText(modelReplaceLogPath, modelReplaceLogStr);
    }

    private static string BrowseForFolder(string dialogTitle)
    {
        FolderBrowserDialog dialog = new()
        {
            Description = dialogTitle,
            UseDescriptionForTitle = true
        };
        return dialog.ShowDialog() != DialogResult.OK ? "" : dialog.SelectedPath;
    }

    private static string[] GetAllFolderFiles(string folderPath, string fileType = "*.*")
    {
        try
        {
            return Directory.GetFiles(folderPath, fileType, SearchOption.AllDirectories);
        }
        catch (Exception)
        {
            return Array.Empty<string>();
        }
    }

    private static string GetModelName(string str, bool upperCase = false)
    {
        string modelName = str.Split('.', str.Count(i => i == '.')).ElementAtOrDefault(0) ?? "";
        modelName = Path.GetFileNameWithoutExtension(modelName);
        return upperCase ? modelName.ToUpper() : modelName;
    }

    private static string GetModelNamePrefix(string modelName)
    {
        if (modelName == "") return "";
        int startIndex = modelName.LastIndexOf('(') + 1;
        if (startIndex == -1) startIndex = 0;
        int endIndex = modelName.IndexOf('_') + 2;
        return endIndex == -1 ? "" : modelName.Substring(startIndex, endIndex - startIndex);
    }

    private static void ShowInformationDialog(string message)
    {
        MessageBox.Show(message, @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private static void ShowErrorDialog(string message)
    {
        MessageBox.Show(message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void ReadModels<T>(List<T> rawModelsList, ICollection<Model> outputModelsList)
    {
        if (appRootPath == "") return;
        bool isTypeString = typeof(T) == typeof(string);
        bool isTypeArchive = typeof(T) == typeof(IArchiveEntry);
        models.Clear();
        string[] csvFiles = Directory.GetFiles(csvsFolderPath);
        string modelNamesListFilePath = csvFiles.FirstOrDefault(i => i.Contains(gameTabs.SelectedTab.Text)) ?? "";
        TextFieldParser parser = new(modelNamesListFilePath);
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        while (!parser.EndOfData)
        {
            string[]? rowFields = parser.ReadFields();
            if (rowFields == null) continue;
            foreach (T entry in rawModelsList)
            {
                if (entry == null) continue;
                string modelPath = "";
                if (isTypeString) modelPath = entry.ToString() ?? "";
                else if (isTypeArchive) modelPath = ((IArchiveEntry)entry).Key;
                bool foundMatch = modelPath.ToLower().Contains(rowFields.ElementAt(1).ToLower());
                if (!foundMatch || rowFields.ElementAt(1) == "") continue;
                Model model = new(modelPath, modelPath, rowFields.ElementAt(2), isTypeString);
                outputModelsList.Add(model);
                break;
            }
        }
    }

    private void ReadAllModelArchives()
    {
        modelArchives.Clear();
        foreach (string path in modelArchiveFilePaths)
        {
            ModelArchive modelArchive = new(path);
            IArchive? modelArchiveFile = null;
            try
            {
                if (path.EndsWith(".zip"))
                    modelArchiveFile = ZipArchive.Open(path);
                else if (path.EndsWith(".rar"))
                    modelArchiveFile = RarArchive.Open(path);
            }
            catch (Exception)
            {
                ShowErrorDialog($"{modelArchive.Name} is corrupted.");
                continue;
            }
            modelArchive = new ModelArchive(path, modelArchiveFile);
            if (modelArchiveFile == null) continue;
            ReadModels(modelArchiveFile.Entries.ToList(), modelArchive.Entries);
            modelArchives.Add(modelArchive);
        }
    }

    private static TreeNode GetModelPartNode(Model model)
    {
        return new TreeNode { BackColor = model.StatusColor, Name = model.Name, Text = model.DispName };
    }

    private void PopulateModelArchivesView(bool refreshData = true, bool saveTreeState = true)
    {
        bool isSelectedNodeAnArchive = true;
        int archiveNodeIndex = 0;
        int modelPartNodeIndex = 0;
        if (saveTreeState)
        {
            isSelectedNodeAnArchive = modelArchivesView.SelectedNode?.Parent == null;
            archiveNodeIndex = isSelectedNodeAnArchive ? modelArchivesView.SelectedNode?.Index ?? 0 : modelArchivesView.SelectedNode?.Parent?.Index ?? 0;
            modelPartNodeIndex = isSelectedNodeAnArchive ? -1 : modelArchivesView.SelectedNode?.Index ?? 0;
        }
        modelArchivesView.Nodes.Clear();
        if (refreshData)
        {
            ReadModelReplaceLog();
            ReadAllModelArchives();
        }
        foreach (ModelArchive archive in modelArchives)
        {
            TreeNode archiveNode = new() { Name = archive.Name, Text = archive.Name };
            List<Model> matchingEntries = archive.Entries;
            if (modelArchivesRadioButton.Checked)
                matchingEntries = matchingEntries.Where(i => DoesMatchSearchQuery(i.DispName)).ToList();
            foreach (Model entry in matchingEntries)
                archiveNode.Nodes.Add(GetModelPartNode(entry));
            modelArchivesView.Nodes.Add(archiveNode);
        }
        modelArchivesView.SelectedNode = modelArchivesView.Nodes[0];
        if (!saveTreeState) return;
        if (isSelectedNodeAnArchive) modelArchivesView.Nodes[archiveNodeIndex].Expand();
        else modelArchivesView.SelectedNode = modelArchivesView.Nodes[archiveNodeIndex].Nodes[modelPartNodeIndex];
    }

    private bool DoesMatchSearchQuery(string query)
    {
        string[] tokens = searchBox.Text.Split(' ');
        return tokens.Any(token => query.ToLower().Contains(token.ToLower()));
    }

    private void PopulateModelReplaceView(TreeNode? selectedArchiveNode)
    {
        if (selectedArchiveNode == null) return;
        modelReplaceButton.Enabled = false;
        modelRestoreButton.Enabled = false;
        modelReplaceView.Nodes.Clear();
        switch (selectedArchiveNode)
        {
            case { Level: 0 }:
                modelReplaceButton.Enabled = true;
                modelRestoreButton.Enabled = true;
                modelReplaceView.Nodes.Add(new TreeNode("Click the Replace button to use the selected set for replacement."));
                modelReplaceView.Nodes.Add(new TreeNode("Click the Restore button to specify a set to restore from backup."));
                break;
            case { Level: 1 }:
            {
                string archiveModelPrefix = GetModelNamePrefix(selectedArchiveNode.Text);
                List<Model> matchingModels = models.Where(i => i.Prefix == archiveModelPrefix).ToList();
                if (modelReplaceRadioButton.Checked) matchingModels = matchingModels.Where(i => DoesMatchSearchQuery(i.DispName)).ToList();
                bool wantsAvailable = filterSearchOptionsBox.SelectedIndex == 1;
                bool wantsReplaced = filterSearchOptionsBox.SelectedIndex == 2;
                matchingModels = matchingModels.Where(i => wantsAvailable ? i.Status == ModelStatus.Available : !wantsReplaced || i.Status == ModelStatus.Taken).ToList();
                if (matchingModels.Count == 0)
                {
                    modelReplaceView.Nodes.Add(new TreeNode($"There are no model parts which match the prefix, {archiveModelPrefix}, or query."));
                    return;
                }
                foreach (Model model in matchingModels)
                    modelReplaceView.Nodes.Add(new TreeNode { ToolTipText = model.NodeTooltip, BackColor = model.StatusColor, Name = model.Name, Text = model.DispName });
                break;
            }
            default:
                modelReplaceView.Nodes.Add(new TreeNode("Select a model part to view available parts to replace."));
                break;
        }
    }

    private void AssignModelTooltips()
    {
        ModelArchive modelArchive = GetCurrentModelArchive();
        foreach (Model model in models)
        {
            string archiveModelDispName = models.Find(i => i.Name == model.ArchiveModelName)?.DispName ?? model.ArchiveModelName;
            model.NodeTooltip = model.Status == ModelStatus.Available ? "Available to replace" : $"{modelArchive.Name}: {archiveModelDispName} -> {model.DispName}";
        }
    }

    private void ReadAllModels()
    {
        ReadModels(modelFilePaths.ToList(), models);
        AssignModelTooltips();
    }

    private void PopulateModelArchives()
    {
        string[] zipFilePaths = GetAllFolderFiles(modelArchivesFolderPath, "*.zip");
        string[] rarFilePaths = GetAllFolderFiles(modelArchivesFolderPath, "*.rar");
        if (zipFilePaths.Length == 0 && rarFilePaths.Length == 0)
        {
            ShowInformationDialog("The selected folder contains no model archives.");
            return;
        }
        modelArchiveFilePaths = zipFilePaths.Concat(rarFilePaths).ToArray();
        modelArchivesFolderPathLabel.Text = modelArchivesFolderPath;
        mainSplitContainer.Enabled = true;
        modelReplaceButton.Enabled = false;
        searchGroupBox.Enabled = true;
        modelReplaceRadioButton.Checked = true;
        filterSearchOptionsBox.SelectedIndex = 0;
        PopulateModelArchivesView(true, false);
        ReadAllModels();
    }

    private void BrowseModelArchivesFolder()
    {
        modelArchivesFolderPath = BrowseForFolder("Select Model Archives Folder");
        if (string.IsNullOrEmpty(modelArchivesFolderPath)) return;
        gamesDatabase[gameTabs.SelectedTab.Text][modelArchivesFolderPathKey] = modelArchivesFolderPath;
        WriteGamesDatabase();
        PopulateModelArchives();
    }

    private void BrowseModelArchivesButton_Click(object sender, EventArgs e)
    {
        BrowseModelArchivesFolder();
    }

    private void PopulateModels()
    {
        modelFilePaths = GetAllFolderFiles(modelsFolderPath, "*.partsbnd.dcx")
            .Concat(GetAllFolderFiles(modelsFolderPath, "*.chrbnd.dcx")).ToArray();
        if (modelFilePaths.Length == 0)
        {
            ShowInformationDialog("The selected folder contains no model files.");
            return;
        }
        modelsFolderPathLabel.Text = Path.GetDirectoryName(modelFilePaths[0]);
        modelArchivesFolderGroupBox.Enabled = true;
    }

    private void BrowseModelsFolder()
    {
        modelsFolderPath = BrowseForFolder("Select Models Folder");
        if (string.IsNullOrEmpty(modelsFolderPath)) return;
        gamesDatabase[gameTabs.SelectedTab.Text][modelsFolderPathKey] = modelsFolderPath;
        WriteGamesDatabase();
        PopulateModels();
    }

    private void BrowseModelsFolderButton_Click(object sender, EventArgs e)
    {
        BrowseModelsFolder();
    }

    private void ModelArchivesView_AfterSelect(object sender, TreeViewEventArgs e)
    {
        PopulateModelReplaceView(e.Node);
    }

    private static bool IsMatch(string sourceStr, string targetStr)
    {
        return sourceStr.Contains(targetStr, StringComparison.OrdinalIgnoreCase);
    }

    private static string ShowInputDialog(string text, string caption)
    {
        Form prompt = new()
        {
            Width = 340,
            Height = 125,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = caption,
            StartPosition = FormStartPosition.CenterScreen,
            MaximizeBox = false
        };
        Label textLabel = new() { Left = 8, Top = 8, Width = 300, Text = text };
        TextBox textBox = new() { Left = 10, Top = 28, Width = 300 };
        Button cancelButton = new() { Text = @"Cancel", Left = 9, Width = 150, Top = 55, DialogResult = DialogResult.Cancel };
        cancelButton.Click += (_, _) => { prompt.Close(); };
        Button confirmation = new() { Text = @"OK", Left = 160, Width = 150, Top = 55, DialogResult = DialogResult.OK };
        confirmation.Click += (_, _) => { prompt.Close(); };
        prompt.Controls.Add(textBox);
        prompt.Controls.Add(cancelButton);
        prompt.Controls.Add(confirmation);
        prompt.Controls.Add(textLabel);
        prompt.AcceptButton = confirmation;
        return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
    }

    private async Task UpdateStatusLabel(bool isVisible, string message, bool shouldDelay)
    {
        if (isVisible) statusLabel.Visible = true;
        statusLabel.Text = message;
        if (shouldDelay) await Task.Delay(2000);
        if (!isVisible) statusLabel.Visible = false;
    }

    private void ExitTaskState()
    {
        WriteModelReplaceLog();
        PopulateModelArchivesView();
        ReadAllModels();
        PopulateModelReplaceView(modelArchivesView.SelectedNode);
    }

    private void DefocusModelActions()
    {
        modelReplaceButton.Enabled = false;
        modelRestoreButton.Enabled = false;
    }

    private async Task<bool> RestoreModel(string modelName, bool shouldDelay = false)
    {
        DefocusModelActions();
        Model model = models.FirstOrDefault(i => modelName.Contains(i.Name)) ?? new Model();
        if (!File.Exists(model.BackupFilePath))
        {
            if (shouldDelay) ShowInformationDialog($"There is no backup file associated with {model.DispName}.");
            return false;
        }
        File.Copy(model.BackupFilePath, model.FilePath, true);
        await UpdateStatusLabel(true, $"Restoring {model.DispName} from backup...", shouldDelay);
        modelReplaceLog.Remove(model.Name);
        if (shouldDelay) ExitTaskState();
        await UpdateStatusLabel(false, "Restoration completed!", shouldDelay);
        return true;
    }

    private async Task ReplaceModel(ModelArchive modelArchive, string archiveModelName, string replaceModelName, bool shouldDelay = false)
    {
        DefocusModelActions();
        Model archiveModel = modelArchive.Entries.FirstOrDefault(i => IsMatch(i.Name, archiveModelName)) ?? new Model();
        if (archiveModel.Name == "") return;
        IArchiveEntry? archiveMdEntry = modelArchive.Archive?.Entries.FirstOrDefault(i => IsMatch(i.Key, archiveModel.Name));
        Stream? archiveMdStream = archiveMdEntry?.OpenEntryStream();
        if (archiveMdStream == null) return;
        Model replaceModel = models.FirstOrDefault(i => replaceModelName.Contains(i.Name)) ?? new Model();
        if (!File.Exists(replaceModel.BackupFilePath)) File.Copy(replaceModel.FilePath, replaceModel.BackupFilePath, true);
        FileStream replaceModelStream = new(replaceModel.FilePath, FileMode.Create, FileAccess.Write);
        await UpdateStatusLabel(true, $"Replacing {replaceModel.DispName} with modified {archiveModel.DispName}...", shouldDelay);
        await archiveMdStream.CopyToAsync(replaceModelStream);
        replaceModelStream.Close();
        JObject modelReplaceEntry = new()
        {
            { archiveModelPartKey, archiveModel.Name },
            { replaceModelPartKey, replaceModel.Name },
            { replaceStatusKey, ModelStatus.Taken.ToString() }
        };
        modelReplaceLog.Add(new JProperty(replaceModel.Name, modelReplaceEntry));
        if (shouldDelay) ExitTaskState();
        await UpdateStatusLabel(false, "Replacement completed!", shouldDelay);
    }

    private static string PromptSetID()
    {
        string idString = ShowInputDialog("Enter the ID of an in-game set:", "Set ID");
        if (idString == "") return "";
        if (int.TryParse(idString, out int id)) return id.ToString();
        ShowInformationDialog("The specified set ID is invalid.");
        return "";
    }

    private static List<Model> GetMatchingSet(string setId)
    {
        List<Model> set = models.Where(i => i.Name.Contains(setId)).ToList();
        if (set.Count == 0) ShowInformationDialog("An in-game set matching the specified ID could not be found.");
        return set;
    }

    private async Task RestoreSet()
    {
        string id = PromptSetID();
        if (id == "") return;
        List<Model> restoreSet = GetMatchingSet(id);
        if (restoreSet.Count == 0) return;
        string modelRestorations = "";
        foreach (Model model in restoreSet)
        {
            if (!await RestoreModel(model.Name)) continue;
            modelRestorations += $"{model.DispName}\n\n";
        }
        ExitTaskState();
        ShowInformationDialog($"The in-game set with ID {id} was successfully restored:\n\n{modelRestorations}");
    }

    private async Task ReplaceSet(ModelArchive modelArchive)
    {
        string id = PromptSetID();
        if (id == "") return;
        List<Model> replaceSet = GetMatchingSet(id);
        if (replaceSet.Count == 0) return;
        string modelReplacements = "";
        foreach (Model model in replaceSet)
        {
            Model archiveModel = modelArchive.Entries.FirstOrDefault(i => i.Prefix == model.Prefix) ?? new Model();
            if (archiveModel.Name == "") continue;
            await ReplaceModel(modelArchive, archiveModel.Name, model.Name);
            modelReplacements += $"{archiveModel.DispName} -> {model.DispName}\n\n";
        }
        ExitTaskState();
        ShowInformationDialog($"The in-game set with ID {id} was successfully replaced with the following:\n\n{modelReplacements}");
    }

    private ModelArchive GetCurrentModelArchive()
    {
        TreeNode modelArchiveNode = modelArchivesView.SelectedNode.Parent ?? modelArchivesView.SelectedNode;
        return modelArchives.FirstOrDefault(i => i.Name == modelArchiveNode.Text) ?? new ModelArchive();
    }

    private async void ModelReplaceButton_Click(object sender, EventArgs e)
    {
        ModelArchive modelArchive = GetCurrentModelArchive();
        if (modelArchive.Name == "") return;
        if (modelArchivesView.SelectedNode.Parent == null) await ReplaceSet(modelArchive);
        else await ReplaceModel(modelArchive, modelArchivesView.SelectedNode.Name, modelReplaceView.SelectedNode.Name, true);
    }

    private void ModelReplaceView_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (modelReplaceView.SelectedNode.Name == "") return;
        modelReplaceButton.Enabled = true;
        modelRestoreButton.Enabled = true;
    }

    private void NodeRightClick(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right) return;
        TreeView treeView = (TreeView)sender;
        if (string.IsNullOrEmpty(treeView.SelectedNode.Name)) return;
        nodeRightClickMenu.ItemClicked += (_, _) =>
        {
            if (treeView.SelectedNode == null) return;
            string nodeName = treeView.SelectedNode.Name;
            Clipboard.SetText(nodeName == "" ? treeView.SelectedNode.Text : nodeName);
        };
        nodeRightClickMenu.Show(treeView, e.X, e.Y);
    }

    private void SearchBox_TextChanged(object sender, EventArgs e)
    {
        if (modelReplaceRadioButton.Checked) PopulateModelReplaceView(modelArchivesView.SelectedNode);
        else PopulateModelArchivesView(false);
    }

    private void FilterSearchOptionsBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (modelReplaceRadioButton.Checked) PopulateModelReplaceView(modelArchivesView.SelectedNode);
        else PopulateModelArchivesView(false);
    }

    private async void ModelRestoreButton_Click(object sender, EventArgs e)
    {
        TreeNode replaceModelNode = modelReplaceView.SelectedNode;
        if (modelArchivesView.SelectedNode.Parent == null) await RestoreSet();
        else await RestoreModel(replaceModelNode.Name, true);
    }

    private void ResetToModelsFolderState()
    {
        modelsFolderPathLabel.Text = @"N/A";
        modelArchivesFolderGroupBox.Enabled = false;
        searchGroupBox.Enabled = false;
        mainSplitContainer.Enabled = false;
    }

    private void ResetToModelArchivesFolderState()
    {
        modelArchivesFolderPathLabel.Text = @"N/A";
        searchGroupBox.Enabled = false;
        mainSplitContainer.Enabled = false;
    }

    private void GameTabs_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (gameTabs.SelectedIndex == -1) return;
        modelsFolderPath = gamesDatabase[gameTabs.SelectedTab.Text][modelsFolderPathKey].ToString();
        modelArchivesFolderPath = gamesDatabase[gameTabs.SelectedTab.Text][modelArchivesFolderPathKey].ToString();
        if (!string.IsNullOrEmpty(modelsFolderPath)) PopulateModels();
        else ResetToModelsFolderState();
        if (!string.IsNullOrEmpty(modelArchivesFolderPath)) PopulateModelArchives();
        else ResetToModelArchivesFolderState();
    }

    private void FSModelUtility_Load(object sender, EventArgs e)
    {
        gameTabs.SelectedIndex = -1;
        gameTabs.SelectedIndex = 0;
    }

    private class Model
    {
        public readonly string BackupFilePath;
        public readonly string DispName;
        public readonly string FilePath;
        public readonly string Name;
        public readonly string Prefix;
        public string ArchiveModelName = "";
        public string NodeTooltip = "";
        public ModelStatus Status = ModelStatus.Available;
        public Color StatusColor;

        public Model(string modelName = "", string filePath = "", string dispName = "", bool useReplaceModelPartName = true)
        {
            Name = GetModelName(modelName, true);
            Prefix = GetModelNamePrefix(Name);
            FilePath = filePath;
            BackupFilePath = $"{FilePath}.bak";
            DispName = dispName == "" ? Name : $"{dispName} ({Name})";
            UpdateStatus(useReplaceModelPartName);
        }

        private void UpdateStatus(bool useReplaceModelPartName)
        {
            StatusColor = Color.PaleGreen;
            foreach (KeyValuePair<string, JToken> entry in modelReplaceLog)
            {
                bool doesReplaceModelMatch = entry.Value[useReplaceModelPartName ? replaceModelPartKey : archiveModelPartKey].ToString() == Name;
                if (!doesReplaceModelMatch) continue;
                bool statusParsed = Enum.TryParse(entry.Value[replaceStatusKey].ToString(), out ModelStatus status);
                if (!statusParsed) continue;
                Status = status;
                StatusColor = Status == ModelStatus.Available ? StatusColor : Color.Khaki;
                ArchiveModelName = entry.Value[archiveModelPartKey].ToString();
            }
        }
    }

    private class ModelArchive
    {
        public readonly IArchive? Archive;
        public readonly List<Model> Entries = new();
        public readonly string Name;

        public ModelArchive(string archiveName = "", IArchive? archive = null)
        {
            Name = GetModelName(archiveName);
            Archive = archive;
        }
    }

    private enum ModelStatus
    {
        Available,
        Taken
    }
}