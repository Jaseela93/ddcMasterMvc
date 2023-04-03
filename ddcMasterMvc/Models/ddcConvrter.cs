using System.Xml;

namespace ddcMasterMvc.Models
{
    public class ddcConvrter
    {
        public IFormFile File { get; set; }
        public string FExtension { get; set; }
        public string FPath { get; set; }
        public void ConvertDDC()
        {
            if (File != null && File.Length > 0)
            {
                
                FExtension = Path.GetExtension(File.FileName);
                if(FExtension==".xml" || FExtension == ".XML")
                {
                    using (var stream = File.OpenReadStream())
                    {
                        // Read the XML file into a stream
                        var xmlDoc = new XmlDocument();
                        xmlDoc.Load(stream);

                        XmlNodeList element = xmlDoc.SelectNodes("//Code");
                        if(element != null)
                        {
                            foreach (XmlNode codeNode in element)
                            {
                                if(codeNode.InnerText.Length >15)
                                {
                                    codeNode.InnerText = "New value";
                                }
                                
                            }
                        }
                        
                        xmlDoc.Save("File/file.xml");
                        
                    }

                }
                else
                {

                }
            }
        }
    }
}
