/*
    This file is part of LDDPartsList.

    LDDPartsList is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    LDDPartsList is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with LDDPartsList. If not, see <http://www.gnu.org/licenses/>.
*/

using System;

namespace LDDPartsList
{
    /// <summary>
    /// Container for Brick informations.
    /// </summary>
    class Brick
    {
        private int itemNos;
        private int designID;
        private int materialID;
        private int count;
        private String Name;

        /// <summary>
        /// Creates a Brick object.
        /// </summary>
        /// <param name="itemNos">The itemNos from the LXFML.</param>
        /// <param name="designID">The designID from the LXFML.</param>
        /// <param name="materialID">The materialID from the LXFML.</param>
        public Brick(int itemNos, int designID, int materialID)
        {
            this.itemNos = itemNos;
            this.designID = designID;
            this.materialID = materialID;
            this.count = 1;
            this.Name = "Unknown";
        }

        /// <summary>
        /// Creates a Brick object.
        /// </summary>
        /// <param name="itemNos">The itemNos from the LXFML.</param>
        /// <param name="designID">The designID from the LXFML.</param>
        /// <param name="materialID">The materialID from the LXFML.</param>
        /// <param name="name">The name of the Brick.</param>
        public Brick(int itemNos, int designID, int materialID, String name)
        {
            this.itemNos = itemNos;
            this.designID = designID;
            this.materialID = materialID;
            this.count = 1;
            this.Name = String.Copy(name);
        }

        /// <summary>
        /// Returns the designID.
        /// </summary>
        /// <returns>designID</returns>
        public int GetDesignID()
        {
            return this.designID;
        }

        /// <summary>
        /// Returns the designID.
        /// </summary>
        /// <returns>designID</returns>
        public int GetItemNo()
        {
            return this.itemNos;
        }

        /// <summary>
        /// Returns the materialID.
        /// </summary>
        /// <returns>materialID</returns>
        public int GetMaterialID()
        {
            return this.materialID;
        }

        /// <summary>
        /// Returns the name of the Brick.
        /// </summary>
        /// <returns>Part's name</returns>
        public string GetName()
        {
            return this.Name;
        }

        /// <summary>
        /// Sets the Brick's name.
        /// </summary>
        /// <param name="newname">New name of the Brick.</param>
        public void SetName(string newname)
        {
            this.Name = String.Copy(newname);
        }

        /// <summary>
        /// Gets how many times this part was used.
        /// </summary>
        /// <returns>The use count.</returns>
        public int GetCount()
        {
            return this.count;
        }
        
        /// <summary>
        /// Increments, how many times this part was used.
        /// </summary>
        public void Increment()
        {
            this.count++;
        }

        public override int GetHashCode()
        {
            return HashCodeCompute(this.designID, this.materialID);
        }

        public override bool Equals(Object obj)
        {
            return (obj.GetHashCode() == this.GetHashCode());
        }

        /// <summary>
        /// Generates a hash from designID and materialID.
        /// Used by Brick.
        /// </summary>
        /// <param name="designID">The designID from the XFML.</param>
        /// <param name="materialID">The materialID from the XFML.</param>
        /// <returns>The hash.</returns>
        public static int HashCodeCompute(int designID, int materialID)
        {
            return designID * 1000 + materialID;
        }
    }
}
