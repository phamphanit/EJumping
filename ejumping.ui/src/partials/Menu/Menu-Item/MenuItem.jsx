import React from "react";
import MenuItemDropdown from "./MenuItemDropdown";

const MenuItem = (props) => {
  return (
    <div className="menu_item_container">
      <div className="menu_head_text">
        <span>{props.children}</span>
        <i className="fas fa-chevron-down ml-1"></i>
      </div>
      <MenuItemDropdown></MenuItemDropdown>
    </div>
  );
};

export default MenuItem;
