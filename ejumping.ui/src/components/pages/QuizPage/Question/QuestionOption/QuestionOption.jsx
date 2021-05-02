import React, { useState } from "react";

const QuestionOption = (props) => {
  const { selected, content, handleClick, index } = props;
  return (
    <div
      className={selected === index ? "option selected" : "option"}
      onClick={() => handleClick(index)}
    >
      <em></em>
      <span>{content}</span>
    </div>
  );
};

export default QuestionOption;
