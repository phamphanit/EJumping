import React, { useState } from "react";
import MenuItemDropdown from "./MenuItemDropdown";
import { Link } from "react-router-dom";

const MenuItem = (props) => {
  const [dropdownMenu, setDropdownMenu] = useState(false);

  return (
    <div
      className="menu_item_container"
      onMouseEnter={() => setDropdownMenu(true)}
      onMouseLeave={() => setDropdownMenu(false)}
    >
      <div className="menu_head_text">
        <Link>
          <span>{props.children}</span>
        </Link>
        <i className="fas fa-chevron-down ml-1"></i>
      </div>
      {dropdownMenu && <MenuItemDropdown></MenuItemDropdown>}
    </div>
  );
};

export default MenuItem;
