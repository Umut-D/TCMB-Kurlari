using System.Data;

namespace tcmb_kurlari.Siniflar
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