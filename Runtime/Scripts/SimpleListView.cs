using System;
using System.Collections.Generic;
using Vrlife.Core.Abstractions;

namespace Vrlife.Core
{
    public class SimpleListView : ListView<SimpleListItem>
    {
        public void BindText(IEnumerable<string> data)
        {
            BindData(data, (str, item) =>
            {
                item.SetText(str);
            });
        }
    }
}