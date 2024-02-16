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
        if (e.Node is not { Level: 1 })
        {
            modelReplaceView.Nodes.Add(new TreeNode("Select a model part to view available parts to replace."));
            return;
        }
        string archiveModelPrefix = GetModelNamePrefix(e.Node.Text);
        List<Model> matchingModels = models.Where(i => i.Prefix == archiveModelPrefix).ToList();
        if (matchingModels.Count == 0)
        {
            modelReplaceView.Nodes.Add(new TreeNode($"There are no model parts which match the prefix {archiveModelPrefix}."));
            return;
        }
        foreach (Model model in matchingModels)
            modelReplaceView.Nodes.Add(new TreeNode { Name = model.Name, Text = model.DispName });
    }

    private static bool IsMatch(string sourceStr, string targetStr)
    {
        return sourceStr.Contains(targetStr, StringComparison.OrdinalIgnoreCase);
    }

    private async void ModelReplaceButton_Click(object sender, EventArgs e)
    {
        modelReplaceButton.Enabled = false;
        TreeNode archiveModelNode = modelArchivesView.SelectedNode;
        TreeNode modelArchiveNode = modelArchivesView.SelectedNode.Parent;
        TreeNode replaceModelNode = modelReplaceView.SelectedNode;
        ModelArchive modelArchive = modelArchives.FirstOrDefault(i => i.Name == modelArchiveNode.Text) ?? new ModelArchive();
        if (modelArchive.Name == "") return;
        Model archiveModel = modelArchive.Entries.FirstOrDefault(i => IsMatch(i.Name, archiveModelNode.Name)) ?? new Model();
        if (archiveModel.Name == "") return;
        IArchiveEntry? archiveMdEntry = modelArchive.Archive?.Entries.FirstOrDefault(i => IsMatch(i.Key, archiveModel.Name));
        Stream? archiveMdStream = archiveMdEntry?.OpenEntryStream();
        if (archiveMdStream == null) return;
        Model replaceModel = models.FirstOrDefault(i => replaceModelNode.Name.Contains(i.Name)) ?? new Model();
        var replaceModelBakFilePath = $"{replaceModel.FilePath}.bak";
        if (!File.Exists(replaceModelBakFilePath)) File.Copy(replaceModel.FilePath, $"{replaceModel.FilePath}.bak", true);
        var replaceModelStream = new FileStream(replaceModel.FilePath, FileMode.Create, FileAccess.Write);
        statusLabel.Visible = true;
        statusLabel.Text = @$"Replacing {replaceModel.DispName} with modified {archiveModel.DispName}...";
        await Task.Delay(2000);
        await archiveMdStream.CopyToAsync(replaceModelStream);
        replaceModelStream.Close();
        statusLabel.Text = @"Replacement completed!";
        await Task.Delay(2000);
        statusLabel.Visible = false;
        modelReplaceButton.Enabled = true;
    }

    private void ModelReplaceView_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (modelReplaceView.SelectedNode.Name == "") return;
        modelReplaceButton.Enabled = true;
    }

    private void ModelReplaceView_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right) return;
        modelReplaceRightClickMenu.ItemClicked += (_, clickEventArgs) =>
        {
            if (modelReplaceRightClickMenu.Items.IndexOf(clickEventArgs.ClickedItem) == 0)
                Clipboard.SetText(modelReplaceView.SelectedNode.Name);
        };
        modelReplaceRightClickMenu.Show(modelReplaceView, e.X, e.Y);
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