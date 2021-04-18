import React from "react";
import MenuItem from "./Menu-Item/MenuItem";
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
                <ul className="cat_menu_list">
                  <li>Computers & Laptops</li>
                  <li>Cameras & Photos</li>
                  <li>Hardware</li>
                  <li>Smartphones & Tablets</li>
                  <li>TV & Audio</li>
                </ul>
              </div>

              <div className="main_menu_container">
                <ul className="menu_items d-flex flex-row">
                  <li>
                    <div className="menu_item_container">
                      <div className="menu_head_text">
                        <span>Home</span>
                      </div>
                    </div>
                  </li>
                  <li>
                    <MenuItem>Super Details</MenuItem>
                  </li>
                  <li>
                    <MenuItem>Featured Brands</MenuItem>
                  </li>
                  <li>
                    <MenuItem>Pages</MenuItem>
                  </li>
                  <li>
                    <div className="menu_item_container">
                      <div className="menu_head_text">
                        <span>Home</span>
                      </div>
                    </div>
                  </li>
                  <li>
                    <div className="menu_item_container">
                      <div className="menu_head_text">
                        <span>Contact</span>
                      </div>
                    </div>
                  </li>
                </ul>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
