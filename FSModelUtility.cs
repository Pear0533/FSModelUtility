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
    private static string modelsFolderPath = "";
    private static string modelArchivesFolderPath = "";
    private static string[] modelArchiveFilePaths = Array.Empty<string>();
    private static string[] modelFilePaths = Array.Empty<string>();
    private static readonly List<ModelArchive> modelArchives = new();
    private static readonly List<Model> models = new();
    private static readonly string appRootPath = Path.GetDirectoryName(Application.ExecutablePath) ?? "";
    private static readonly string modelReplaceLogPath = $"{appRootPath}\\model_replace_log.json";
    private static JObject modelReplaceLog = new();
    private const string version = "1.0";

    public FSModelUtility()
    {
        InitializeComponent();
        CenterToScreen();
        SetVersionString();
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

    private static void ReadModels<T>(List<T> rawModelsList, ICollection<Model> outputModelsList)
    {
        if (appRootPath == "") return;
        bool isTypeString = typeof(T) == typeof(string);
        bool isTypeArchive = typeof(T) == typeof(IArchiveEntry);
        models.Clear();
        string modelNamesListFilePath = $"{appRootPath}\\modelnames.csv";
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

    private static void ReadAllModelArchives()
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

    private void PopulateModelArchivesView()
    {
        modelArchivesView.Nodes.Clear();
        ReadModelReplaceLog();
        ReadAllModelArchives();
        foreach (ModelArchive archive in modelArchives)
        {
            TreeNode archiveNode = new(archive.Name);
            foreach (Model entry in archive.Entries)
                archiveNode.Nodes.Add(GetModelPartNode(entry));
            modelArchivesView.Nodes.Add(archiveNode);
        }
        modelArchivesView.SelectedNode = modelArchivesView.Nodes[0];
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
                break;
            case { Level: 1 }:
                {
                    string archiveModelPrefix = GetModelNamePrefix(selectedArchiveNode.Text);
                    List<Model> matchingModels = models.Where(i => i.Prefix == archiveModelPrefix).ToList();
                    matchingModels = matchingModels.Where(i => DoesMatchSearchQuery(i.DispName)).ToList();
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

    private static void AssignModelTooltips()
    {
        foreach (Model model in models)
        {
            string archiveModelDispName = models.Find(i => i.Name == model.ArchiveModelName)?.DispName ?? model.ArchiveModelName;
            model.NodeTooltip = model.Status == ModelStatus.Available ? "Available to replace" : $"Replaced with {archiveModelDispName}";
        }
    }

    private static void ReadAllModels()
    {
        ReadModels(modelFilePaths.ToList(), models);
        AssignModelTooltips();
    }

    private void BrowseModelArchivesFolder()
    {
        modelArchivesFolderPath = BrowseForFolder("Select Model Archives Folder");
        if (modelArchivesFolderPath == "") return;
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
        PopulateModelArchivesView();
        ReadAllModels();
    }

    private void BrowseModelArchivesButton_Click(object sender, EventArgs e)
    {
        BrowseModelArchivesFolder();
    }

    private void BrowseModelsFolder()
    {
        modelsFolderPath = BrowseForFolder("Select Models Folder");
        if (modelsFolderPath == "") return;
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

    private async Task ReplaceModel(ModelArchive modelArchive, string archiveModelName, string replaceModelName, bool shouldDelay = false)
    {
        modelReplaceButton.Enabled = false;
        Model archiveModel = modelArchive.Entries.FirstOrDefault(i => IsMatch(i.Name, archiveModelName)) ?? new Model();
        if (archiveModel.Name == "") return;
        IArchiveEntry? archiveMdEntry = modelArchive.Archive?.Entries.FirstOrDefault(i => IsMatch(i.Key, archiveModel.Name));
        Stream? archiveMdStream = archiveMdEntry?.OpenEntryStream();
        if (archiveMdStream == null) return;
        Model replaceModel = models.FirstOrDefault(i => replaceModelName.Contains(i.Name)) ?? new Model();
        string replaceModelBakFilePath = $"{replaceModel.FilePath}.bak";
        if (!File.Exists(replaceModelBakFilePath)) File.Copy(replaceModel.FilePath, $"{replaceModel.FilePath}.bak", true);
        FileStream replaceModelStream = new(replaceModel.FilePath, FileMode.Create, FileAccess.Write);
        statusLabel.Visible = true;
        statusLabel.Text = @$"Replacing {replaceModel.DispName} with modified {archiveModel.DispName}...";
        if (shouldDelay) await Task.Delay(2000);
        await archiveMdStream.CopyToAsync(replaceModelStream);
        replaceModelStream.Close();
        JObject modelReplaceEntry = new()
        {
            { archiveModelPartKey, archiveModel.Name },
            { replaceModelPartKey, replaceModel.Name },
            { replaceStatusKey, ModelStatus.Taken.ToString() }
        };
        modelReplaceLog.Add(new JProperty($"{archiveModel.Name} -> {replaceModel.Name}", modelReplaceEntry));
        WriteModelReplaceLog();
        bool isSelectedNodeAnArchive = modelArchivesView.SelectedNode.Parent == null;
        int archiveNodeIndex = isSelectedNodeAnArchive ? modelArchivesView.SelectedNode.Index : modelArchivesView.SelectedNode.Parent!.Index;
        int modelPartNodeIndex = isSelectedNodeAnArchive ? -1 : modelArchivesView.SelectedNode.Index;
        PopulateModelArchivesView();
        if (isSelectedNodeAnArchive) modelArchivesView.Nodes[archiveNodeIndex].Expand();
        else modelArchivesView.SelectedNode = modelArchivesView.Nodes[archiveNodeIndex].Nodes[modelPartNodeIndex];
        ReadAllModels();
        PopulateModelReplaceView(modelArchivesView.SelectedNode);
        statusLabel.Text = @"Replacement completed!";
        if (shouldDelay) await Task.Delay(2000);
        statusLabel.Visible = false;
        modelReplaceButton.Enabled = true;
    }

    private async Task ReplaceSet(ModelArchive modelArchive)
    {
        string replaceSetId = ShowInputDialog("Enter the ID of an in-game set to replace:", "Set ID");
        if (replaceSetId == "") return;
        if (int.TryParse(replaceSetId, out int _))
        {
            List<Model> replaceSet = models.Where(i => i.Name.Contains(replaceSetId)).ToList();
            if (replaceSet.Count == 0) ShowInformationDialog("An in-game set matching the specified ID could not be found.");
            else
            {
                string modelReplacements = "";
                foreach (Model model in replaceSet)
                {
                    Model archiveModel = modelArchive.Entries.FirstOrDefault(i => i.Prefix == model.Prefix) ?? new Model();
                    if (archiveModel.Name == "") continue;
                    await ReplaceModel(modelArchive, archiveModel.Name, model.Name);
                    modelReplacements += $"{archiveModel.DispName} -> {model.DispName}\n\n";
                }
                ShowInformationDialog($"The in-game set with ID {replaceSetId} was successfully replaced with the following:\n\n{modelReplacements}");
            }
        }
        else ShowInformationDialog("The specified set ID is invalid.");
    }

    private async void ModelReplaceButton_Click(object sender, EventArgs e)
    {
        TreeNode archiveModelNode = modelArchivesView.SelectedNode;
        TreeNode modelArchiveNode = modelArchivesView.SelectedNode.Parent ?? archiveModelNode;
        TreeNode replaceModelNode = modelReplaceView.SelectedNode;
        ModelArchive modelArchive = modelArchives.FirstOrDefault(i => i.Name == modelArchiveNode.Text) ?? new ModelArchive();
        if (modelArchive.Name == "") return;
        if (modelArchivesView.SelectedNode.Parent == null) await ReplaceSet(modelArchive);
        else await ReplaceModel(modelArchive, archiveModelNode.Name, replaceModelNode.Name, true);
    }

    private void ModelReplaceView_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (modelReplaceView.SelectedNode.Name == "") return;
        modelReplaceButton.Enabled = true;
    }

    private void NodeRightClick(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right) return;
        TreeView treeView = (TreeView)sender;
        nodeRightClickMenu.ItemClicked += (_, _) =>
        {
            string nodeName = treeView.SelectedNode.Name;
            Clipboard.SetText(nodeName == "" ? treeView.SelectedNode.Text : nodeName);
        };
        nodeRightClickMenu.Show(treeView, e.X, e.Y);
    }

    private void SearchBox_TextChanged(object sender, EventArgs e)
    {
        if (modelReplaceRadioButton.Checked) PopulateModelReplaceView(modelArchivesView.SelectedNode);
    }

    private void FilterSearchOptionsBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (modelReplaceRadioButton.Checked) PopulateModelReplaceView(modelArchivesView.SelectedNode);
    }

    private class Model
    {
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