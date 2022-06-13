using System;
using System.Collections;

namespace WinFormsApp1.Controls
{
    public class clsPanelList : DictionaryBase
    {
        public void Add(int nIndex, Controls.TablePanel item)
        {
            try
            {
                Dictionary.Add(nIndex.ToString(), item);
            }
            catch
            {

            }
        }

        public void Remove(int nIndex)
        {
            Dictionary.Remove(nIndex.ToString());
        }

        public Controls.TablePanel this[int nIndex]
        {
            get
            {
                return (Controls.TablePanel)Dictionary[nIndex.ToString()];
            }
            set
            {
                Dictionary[nIndex.ToString()] = value;
            }
        }
    }

    public class clsPngPanelList : DictionaryBase
    {
        public void Add(int nIndex, Controls.PngTablePanel item)
        {
            try
            {
                Dictionary.Add(nIndex.ToString(), item);
            }
            catch
            {

            }
        }

        public void Remove(int nIndex)
        {
            Dictionary.Remove(nIndex.ToString());
        }

        public Controls.PngTablePanel this[int nIndex]
        {
            get
            {
                return (Controls.PngTablePanel)Dictionary[nIndex.ToString()];
            }
            set
            {
                Dictionary[nIndex.ToString()] = value;
            }
        }
    }

}
