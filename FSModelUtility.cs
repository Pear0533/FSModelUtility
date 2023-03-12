using Microsoft.VisualBasic.FileIO;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.Zip;
using SearchOption = System.IO.SearchOption;

namespace FSModelUtility;

public partial class FSModelUtility : Form
{
    private static string modelsFolderPath = "";
    private static string modelArchivesFolderPath = "";
    private static string[] modelArchiveFilePaths = Array.Empty<string>();
    private static string[] modelFilePaths = Array.Empty<string>();
    private static readonly List<ModelArchive> modelArchives = new();
    private static readonly List<Model> models = new();
    private static readonly string appRootPath = Path.GetDirectoryName(Application.ExecutablePath) ?? "";

    public FSModelUtility()
    {
        InitializeComponent();
        CenterToScreen();
    }

    private static string BrowseForFolder(string dialogTitle)
    {
        var dialog = new FolderBrowserDialog
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
        string modelName = str.Split('.', str.Count(i => i == '.')).ElementAtOrDefault(0) ?? "TEXT HERE";
        modelName = Path.GetFileNameWithoutExtension(modelName);
        return upperCase ? modelName.ToUpper() : modelName;
    }

    private static string GetModelNamePrefix(string modelName)
    {
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
        models.Clear();
        var modelNamesListFilePath = $"{appRootPath}\\modelnames.csv";
        var parser = new TextFieldParser(modelNamesListFilePath);
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        while (!parser.EndOfData)
        {
            string[]? rowFields = parser.ReadFields();
            if (rowFields == null) continue;
            foreach (T entry in rawModelsList)
            {
                if (entry == null) continue;
                var modelPath = "";
                if (typeof(T) == typeof(string)) modelPath = entry.ToString() ?? "";
                else if (typeof(T) == typeof(IArchiveEntry)) modelPath = ((IArchiveEntry)entry).Key;
                bool foundMatch = modelPath.ToLower().Contains(rowFields.ElementAt(1).ToLower());
                if (!foundMatch || rowFields.ElementAt(1) == "") continue;
                outputModelsList.Add(new Model(modelPath, modelPath, rowFields.ElementAt(2)));
                break;
            }
        }
    }

    private static void ReadAllModelArchives()
    {
        modelArchives.Clear();
        foreach (string path in modelArchiveFilePaths)
        {
            var modelArchive = new ModelArchive(path);
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

    private void PopulateModelArchivesView()
    {
        modelArchivesView.Nodes.Clear();
        ReadAllModelArchives();
        foreach (ModelArchive archive in modelArchives)
        {
            var archiveNode = new TreeNode(archive.Name);
            foreach (Model entry in archive.Entries)
                archiveNode.Nodes.Add(new TreeNode { Name = entry.Name, Text = entry.DispName });
            modelArchivesView.Nodes.Add(archiveNode);
        }
        modelArchivesView.SelectedNode = modelArchivesView.Nodes[0];
    }

    private void UpdateModelArchives()
    {
        if (modelArchiveFilePaths.Length == 0) return;
        mainSplitContainer.Enabled = true;
        modelReplaceButton.Enabled = false;
        PopulateModelArchivesView();
        ReadModels(modelFilePaths.ToList(), models);
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
        UpdateModelArchives();
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
        modelsFolderPathLabel.Text = modelsFolderPath;
        modelArchivesFolderGroupBox.Enabled = true;
        UpdateModelArchives();
    }

    private void BrowseModelsFolderButton_Click(object sender, EventArgs e)
    {
        BrowseModelsFolder();
    }

    private void ModelArchivesView_AfterSelect(object sender, TreeViewEventArgs e)
    {
        modelReplaceButton.Enabled = false;
        modelReplaceView.Nodes.Clear();
        switch (e.Node)
        {
            case { Level: 0 }:
                modelReplaceButton.Enabled = true;
                modelReplaceView.Nodes.Add(new TreeNode("Click the Replace button to use the selected set for replacement."));
                break;
            case { Level: 1 }:
            {
                string archiveModelPrefix = GetModelNamePrefix(e.Node.Text);
                List<Model> matchingModels = models.Where(i => i.Prefix == archiveModelPrefix).ToList();
                if (matchingModels.Count == 0)
                {
                    modelReplaceView.Nodes.Add(new TreeNode($"There are no model parts which match the prefix {archiveModelPrefix}."));
                    return;
                }
                foreach (Model model in matchingModels)
                    modelReplaceView.Nodes.Add(new TreeNode { Name = model.Name, Text = model.DispName });
                break;
            }
            default:
                modelReplaceView.Nodes.Add(new TreeNode("Select a model part to view available parts to replace."));
                break;
        }
    }

    private static bool IsMatch(string sourceStr, string targetStr)
    {
        return sourceStr.Contains(targetStr, StringComparison.OrdinalIgnoreCase);
    }

    private static string ShowInputDialog(string text, string caption)
    {
        var prompt = new Form
        {
            Width = 340,
            Height = 125,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = caption,
            StartPosition = FormStartPosition.CenterScreen,
            MaximizeBox = false
        };
        var textLabel = new Label { Left = 8, Top = 8, Width = 300, Text = text };
        var textBox = new TextBox { Left = 10, Top = 28, Width = 300 };
        var cancelButton = new Button { Text = @"Cancel", Left = 9, Width = 150, Top = 55, DialogResult = DialogResult.Cancel };
        cancelButton.Click += (_, _) => { prompt.Close(); };
        var confirmation = new Button { Text = @"OK", Left = 160, Width = 150, Top = 55, DialogResult = DialogResult.OK };
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
        var replaceModelBakFilePath = $"{replaceModel.FilePath}.bak";
        if (!File.Exists(replaceModelBakFilePath)) File.Copy(replaceModel.FilePath, $"{replaceModel.FilePath}.bak", true);
        var replaceModelStream = new FileStream(replaceModel.FilePath, FileMode.Create, FileAccess.Write);
        statusLabel.Visible = true;
        statusLabel.Text = @$"Replacing {replaceModel.DispName} with modified {archiveModel.DispName}...";
        if (shouldDelay) await Task.Delay(2000);
        await archiveMdStream.CopyToAsync(replaceModelStream);
        replaceModelStream.Close();
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
                var modelReplacements = "";
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
        var treeView = (TreeView)sender;
        nodeRightClickMenu.ItemClicked += (_, _) =>
        {
            string nodeName = treeView.SelectedNode.Name;
            Clipboard.SetText(nodeName == "" ? treeView.SelectedNode.Text : nodeName);
        };
        nodeRightClickMenu.Show(treeView, e.X, e.Y);
    }

    private class Model
    {
        public readonly string DispName;
        public readonly string FilePath;
        public readonly string Name;
        public readonly string Prefix;

        public Model(string modelName = "", string filePath = "", string dispName = "")
        {
            Name = GetModelName(modelName, true);
            Prefix = GetModelNamePrefix(Name);
            FilePath = filePath;
            DispName = dispName == "" ? Name : $"{dispName} ({Name})";
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
}