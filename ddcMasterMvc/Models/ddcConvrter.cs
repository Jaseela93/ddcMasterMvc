using ddcMasterMvc.Data;
using System.Xml;

namespace ddcMasterMvc.Models
{
    public class ddcConvrter
    {
        public IFormFile File { get; set; }
        public string FExtension { get; set; }
        public string FPath { get; set; }
        public string mohapCode { get; set; } = string.Empty;
        public void ConvertDDC()
        {
            tblDDCmaster ob = new tblDDCmaster();
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
                                    mohapCode = codeNode.InnerText;
                                    if(mohapCode != string.Empty)
                                    {
                                        codeNode.InnerText = ob.getDHAcode(mohapCode);
                                    }
                                                                       
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
