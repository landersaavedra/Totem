using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Xml;

namespace TotemMarketing.CoreStream.Communication.IContrato
{
    interface ITotemControlCommunication
    {
        [OperationContract]
        XmlDocument getXMLBase64Frames(string strFileName, double strartPosition, double endPosition);

        [OperationContract]
        XmlDocument getXMLBase64ClipInfo(string strFileName);
    }
}
