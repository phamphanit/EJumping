import React from "react";
import PropTypes from "prop-types";

const ClickButton = (props) => {
  const { pagination, handleClick } = props;
  const { page, pageSize } = pagination;
  return (
    <div>
      <button
        disabled={page <= 1}
        className="previous"
        onClick={() => handleClick({ page: page - 1, pageSize })}
      >
        Previous Page
      </button>
      <button
        className="next"
        onClick={() => handleClick({ page: page + 1, pageSize })}
      >
        Next Page
      </button>
    </div>
  );
};

ClickButton.propTypes = {};

export default ClickButton;
