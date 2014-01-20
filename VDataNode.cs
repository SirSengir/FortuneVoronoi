using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSimulator.Utils.Voronoi {

    internal class VDataNode : VNode {

        public VDataNode(Vector DP) {
            this.DataPoint = DP;
        }

        public Vector DataPoint;
    }

}
