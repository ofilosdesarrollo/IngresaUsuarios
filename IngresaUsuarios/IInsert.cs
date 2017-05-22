using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace IngresaUsuarios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInsert" in both code and config file together.
    [ServiceContract]
    public interface IInsert
    {
        [OperationContract]
        string PruebaTexto(string valor);

        [OperationContract]
        string PruebaConexion();

        [OperationContract]
        DataSet PoblarDGV();
        
    }
}
