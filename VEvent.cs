using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSimulator.Utils.Voronoi {

    internal abstract class VEvent : IComparable {

        public abstract double Y { get; }
        public abstract double X { get; }

        #region IComparable Members

        public int CompareTo(object obj) {
            if (!(obj is VEvent))
                throw new ArgumentException("obj not VEvent!");
            int i = Y.CompareTo(((VEvent)obj).Y);
            if (i != 0)
                return i;
            return X.CompareTo(((VEvent)obj).X);
        }

        #endregion
    }

    internal class VDataEvent : VEvent {

        public Vector DataPoint;

        public VDataEvent(Vector DP) {
            this.DataPoint = DP;
        }

        public override double Y {
            get {
                return DataPoint[1];
            }
        }

        public override double X {
            get {
                return DataPoint[0];
            }
        }

    }

    internal class VCircleEvent : VEvent {

        public VDataNode NodeN, NodeL, NodeR;
        public Vector Center;

        public override double Y {
            get {
                return Math.Round(Center[1] + MathTools.Dist(NodeN.DataPoint[0], NodeN.DataPoint[1], Center[0], Center[1]), 10);
            }
        }

        public override double X {
            get {
                return Center[0];
            }
        }

        public bool Valid = true;
    }

}
