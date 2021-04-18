import React from "react";
import "./PageMenu.scss";
export const PageMenu = () => {
  return (
    <div className="main_nav">
      <div className="container">
        <div className="row">
          <div className="col">
            <div className="content d-flex flex-row">
              <div className="cat_menu_container">
                <div className="burger">
                  <span></span>
                  <span></span>
                  <span></span>
                </div>
                <div className="burger_text">Categories</div>
              </div>
              <ul className="cat_menu_list">
                <li>Computers & Laptops</li>
                <li>Cameras & Photos</li>
                <li>Hardware</li>
                <li>Smartphones & Tablets</li>
                <li>TV & Audio</li>
              </ul>
              <div className="main_menu_container">
                <ul className="menu_items d-flex flex-row">
                  <li>Home</li>
                  <li>Super Detail</li>
                  <li>Featured Brands</li>
                  <li>Pages</li>
                  <li>Blog</li>
                  <li>Contact</li>
                </ul>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
