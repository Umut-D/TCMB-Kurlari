using System.Data;

namespace TcmbLibrary
{
    public class DataSetIslem
    {
        public DataSet Olustur(string link)
        {
            DataSet dataSet = new DataSet();
            dataSet.Clear();
            dataSet.ReadXml(link);

            return dataSet;
        }
    }
}