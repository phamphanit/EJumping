import React, { useState } from "react";
import { Link } from "react-router-dom";
import MenuItem from "./Menu-Item/MenuItem";
import "./PageMenu.scss";
import Question from "./../../components/pages/QuizPage/Question/Question";
export const PageMenu = () => {
  const [dropdownMenu, setDropdownMenu] = useState(false);
  return (
    <div className="main_nav">
      <div className="container">
        <div className="row">
          <div className="col">
            <div className="content d-flex flex-row">
              <div
                className="cat_menu_container"
                onMouseEnter={() => setDropdownMenu(true)}
                onMouseLeave={() => setDropdownMenu(false)}
              >
                <div className="burger">
                  <span></span>
                  <span></span>
                  <span></span>
                </div>
                <div className="burger_text">Categories</div>
                {dropdownMenu ? (
                  <ul className="cat_menu_list">
                    <li>Computers & Laptops</li>
                    <li>Cameras & Photos</li>
                    <li>Hardware</li>
                    <li>Smartphones & Tablets</li>
                    <li>TV & Audio</li>
                  </ul>
                ) : null}
              </div>

              <div className="main_menu_container">
                <ul className="menu_items d-flex flex-row">
                  <li>
                    <div className="menu_item_container">
                      <div className="menu_head_text">
                        <Link to="/">
                          <span>Home</span>
                        </Link>
                      </div>
                    </div>
                  </li>
                  <li>
                    <div className="menu_item_container">
                      <div className="menu_head_text">
                        <Link to="/quiz">
                          <span>Question</span>
                        </Link>
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
