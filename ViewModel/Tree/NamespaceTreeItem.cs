﻿using System.Collections.ObjectModel;
using System.Linq;
using BusinessLogic.Model;
using ViewModel.Base;
using ViewModel.Enums;

namespace ViewModel.Tree
{
    public class NamespaceTreeItem : TreeViewItem
    {
        public NamespaceModel NamespaceModel { get; set; }
        public override string Name { get; set; }
        public NamespaceTreeItem(NamespaceModel namespaceModel) : base(namespaceModel.Name)
        {
            NamespaceModel = namespaceModel;
            TreeType = TreeTypeEnum.Namespace;
            Children = PrepareChildrenInstance();
        }

        public sealed override ObservableCollection<TreeViewItem> PrepareChildrenInstance()
        {
            var ret = new ObservableCollection<TreeViewItem>();
            if (NamespaceModel.Types.Count() != 0 || NamespaceModel.Namespaces.Count() != 0)
                ret.Add(null);
            return ret;
        }

        public override void BuildMyself()
        {
            base.BuildMyself();
            foreach (var typeModel in NamespaceModel.Types)
            {
                Children.Add(new TypeTreeItem(typeModel));
            }

            foreach (var namespaceModel in NamespaceModel.Namespaces)
            {
                Children.Add(new NamespaceTreeItem(namespaceModel));
            }
        }
    }
}
