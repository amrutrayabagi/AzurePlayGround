using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MARKEM.PlugIns;
using MARKEM.Service.Api;
using MARKEM.Service.Api.Devices;
using MARKEM.Service.Api.Utilities;
using MARKEM.Service.Core.Interfaces;
using UberSampleService;

[assembly: PublishType("CAPIFeature.URI", typeof(MySampleService))]
namespace UberSampleService
{
    [Browsable(false)]
    public class MySampleService : ISystemServiceInit, ISystemServiceController, IConfigurable
    {
        private INodeManager cm;

        private IEventManager em;
        public string Name
        {
            get
            {
                return "MySampleService";
            }
        }

        public int Priority { get; }

        public void Initialize(IServiceContainer serviceContainer)
        {
            var s = (ISystemServiceContainer)serviceContainer.GetService(typeof(ISystemServiceContainer));
            cm = (INodeManager)s.GetService(StockSystemServices.NodeManager);
            em = (IEventManager)serviceContainer.GetService(typeof(IEventManager));
        }

        public void Start()
        {
            MiFile.WriteAllText("NodesList.txt", string.Join("||", cm.Nodes.Select(x => x.Name)));
            em.Subscribe(Update, StockEvents.Network);
            //throw new NotImplementedException();

        }

        private void Update(IEvent e)
        {
            NetworkChangedEvent nodeAdded = e as NetworkChangedEvent;
            if (nodeAdded != null)
                MiFile.AppendAllText("NodesList.txt", nodeAdded.Node.GetName());

        }

        public void Stop()
        {
            //throw new NotImplementedException();

        }

        public IDictionary Configuration { get; set; }
    }
}
