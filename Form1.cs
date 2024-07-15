using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Tekla.Structures;
using Tekla.Structures.Model;
using MUI = Tekla.Structures.Model.UI;
using TSMO = Tekla.Structures.Model.Operations;

namespace TestReports
{
    public partial class Form1 : Form
    {
        private readonly Model _model = new Model();

        public Form1()
        {
            InitializeComponent();
        }

        private void BTN_Start_Click(object sender, EventArgs e)
        {
            string repPath = "";
            TeklaStructuresSettings.GetAdvancedOption("XS_TEMPLATE_DIRECTORY", ref repPath);

            if (repPath.Split(';').Count() > 1)
                repPath = repPath.Split(';')[1] + @"\";

            if (repPath == "")
            {
                TeklaStructuresSettings.GetAdvancedOption("XS_TEMPLATE_DIRECTORY_SYSTEM", ref repPath);
                if (repPath.Split(';').Count() > 1)
                    repPath = repPath.Split(';')[1] + @"\";
            }
            string repName = "Codes.xml";
            string OutRepPath = Path.Combine(repPath, repName + ".rpt");

            byte[] rep = Properties.Resources.Codes_xml;
            var repS = Encoding.Default.GetString(rep);

            if (!Directory.Exists(repPath))
                Directory.CreateDirectory(repPath);
            var writer = new StreamWriter(OutRepPath, false, Encoding.Default);
            writer.Write(repS);
            writer.Close();

            var MUIO = new MUI.ModelObjectSelector();
            var ME = MUIO.GetSelectedObjects();
            ME.SelectInstances = false;

            if (File.Exists(OutRepPath))
                File.Delete(OutRepPath);

            var assemblyDataSet = Reports.ReportDataSet(_model, repName, false, "", "", "");
            var assemblies = assemblyDataSet.Tables["Assembly"];
        }
    }
    static class Reports
    {
        /// <summary>
        /// Парсит xml в DataSet
        /// </summary>
        public static DataSet ReportDataSet(Model model, string reportName, bool fromAll, string title1, string title2, string title3)
        {
            string reportFile;
            var repOutPath = ReportDirectoryPath(model);

            var user = SystemInformation.UserName;

            reportFile = repOutPath + user + "_" + reportName;

            if (fromAll)
                if (!TSMO.Operation.CreateReportFromAll(reportName, reportFile, title1, title2, title3))
                    MessageBox.Show("Ошибка при создании отчёта!");
            else
                if (!TSMO.Operation.CreateReportFromSelected(reportName, reportFile, title1, title2, title3))
                    MessageBox.Show("Ошибка при создании отчёта!");

            //Считываем данные из созданного xml
            XmlDocument document = new XmlDocument
            {
                PreserveWhitespace = false
            };
            document.Load(reportFile);

            // Получаем данные из созданного отчёта в DataSet
            string xmlString = File.ReadAllText(reportFile, Encoding.GetEncoding(1251));

            var element = XElement.Parse(xmlString);
            element.TrimWhiteSpaceFromValues();

            var reportDataSet = new DataSet();
            reportDataSet.ReadXml(element.CreateReader());

            return reportDataSet;
        }

        public static string ReportDirectoryPath(Model model)
        {
            string modelPath = model.GetInfo().ModelPath;
            string repOutPath = "";

            //Проверяем наличие папки с отчётами  
            TeklaStructuresSettings.GetAdvancedOption("XS_REPORT_OUTPUT_DIRECTORY", ref repOutPath);
            repOutPath = modelPath + repOutPath.Replace(".", "") + @"\";
            if (!Directory.Exists(repOutPath))
                Directory.CreateDirectory(repOutPath);

            return repOutPath;
        }

        /// <summary>
        /// Удаляет лишние пробелы из тегов
        /// </summary>
        public static void TrimWhiteSpaceFromValues(this XElement element)
        {
            foreach (var descendent in element.Descendants())
            {
                if (!descendent.HasElements)
                    descendent.SetValue(descendent.Value.Trim());
                else
                    descendent.TrimWhiteSpaceFromValues();
            }
        }
    }
}