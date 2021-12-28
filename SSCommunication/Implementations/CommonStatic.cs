using SSCommunication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using SSCommunication.Interfaces;

namespace SSCommunication.Implementations
{
    public static class CommonStatic
    {
        public static GenericHttpResponse<string> GetHttpStringResponse(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream str = response.GetResponseStream();
                StreamReader rdr = new StreamReader(str);
                return new GenericHttpResponse<string> { Data = rdr.ReadToEnd(), statusCode = HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                //TODO : Add Logging
                return new GenericHttpResponse<string> { statusCode = HttpStatusCode.InternalServerError, Message = ex.Message };
            }
        }

        public static string HtmlTemplateParsing<TData>(string templateBody, TData data) where TData : IEmailTemplate
        {
            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(templateBody);
                foreach (var property in data.Fields)
                {

                    if (property.Tag == Enum.EmailTemplateTag.Anchor)
                    {
                        var nodes = doc.DocumentNode.SelectNodes("//a[@class='" + property.FieldIndentifier + "']");
                        foreach (var node in nodes)
                        {
                            node.SetAttributeValue("href", property.TagValue);
                        }
                    }
                    else if (property.Tag == Enum.EmailTemplateTag.Img)
                    {
                        var nodes = doc.DocumentNode.SelectNodes("//img[@class='" + property.FieldIndentifier + "']");
                        foreach (var node in nodes)
                        {
                            node.SetAttributeValue("src", property.TagValue);
                        }
                    }
                    else if (property.Tag == Enum.EmailTemplateTag.Span)
                    {
                        var nodes = doc.DocumentNode.SelectNodes("//span[@class='" + property.FieldIndentifier + "']");
                        foreach (var node in nodes)
                        {
                            node.InnerHtml = property.TagValue;
                        }
                    }
                    else if (property.Tag == Enum.EmailTemplateTag.Table)
                    {
                        var nodes = doc.DocumentNode.SelectNodes("//table[@class='" + property.FieldIndentifier + "']");
                        foreach (var node in nodes)
                        {
                            node.InnerHtml = property.TagValue;
                        }
                    }
                    else
                    {
                        var nodes = doc.DocumentNode.SelectNodes("//div[@class='" + property.FieldIndentifier + "']");
                        foreach (var node in nodes)
                        {
                            node.InnerHtml = property.TagValue;
                        }
                    }
                }
                return doc.DocumentNode.OuterHtml;
            }
            catch (Exception ex)
            {
                //TODO : Add Logging
                return templateBody;
            }
        }
    }
}
