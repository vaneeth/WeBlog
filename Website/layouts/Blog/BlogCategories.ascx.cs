﻿using System;
using Sitecore.Links;
using Sitecore.Modules.WeBlog.Items.Blog;
using Sitecore.Modules.WeBlog.Managers;

namespace Sitecore.Modules.WeBlog.Layouts
{
    public partial class BlogCategories : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                titleCategories.Item = CurrentBlog.InnerItem;
                LoadCategories();
            }
        }

        /// <summary>
        /// Load the categories into this control
        /// </summary>
        protected virtual void LoadCategories()
        {
            if (CategoryManager.GetCategories().Length == 0)
            {
                PanelCategories.Visible = false;
            }
            else
            {
                ListViewCategories.DataSource = CategoryManager.GetCategories();
                ListViewCategories.DataBind();
            }
        }

        /// <summary>
        /// Get the URL for a category
        /// </summary>
        /// <param name="category">The category to get the URL for</param>
        /// <returns>The URL if the category is valid, otherwise an emtpy string</returns>
        protected virtual string GetCategoryUrl(CategoryItem category)
        {
            if (category != null)
                return LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(category.ID));
            else
                return string.Empty;
        }
    }
}