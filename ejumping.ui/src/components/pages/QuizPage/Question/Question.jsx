import React from "react";
import "./Question.scss";
const Question = () => {
  return (
    <div className="question-main">
      <div className="title d-flex flex-row">
        <div className="number mr-3">1</div>
        <div className="name"> Can i park here?</div>
      </div>
      <div className="options">
        <div className="option">
          <input type="radio" />
          <span>Sorry, I did that</span>
        </div>
        <div className="option">
          <input type="radio" />
          <span>It's the same place.</span>
        </div>
        <div className="option">
          <input type="radio" />
          <span>Only for half an hour.</span>
        </div>
        <div className="bottom">---</div>
      </div>
    </div>
  );
};

export default Question;
