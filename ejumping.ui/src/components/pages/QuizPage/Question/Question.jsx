import React, { useState } from "react";
import "./Question.scss";
import QuestionOption from "./QuestionOption/QuestionOption";
const Question = (props) => {
  const { question } = props;
  // const options = ["I don't know", "Just do that", "I am not sure"];
  const options = [
    question.firstOption,
    question.secondOption,
    question.thirdOption,
    question.fouthOption,
  ];
  const [selected, setSelected] = useState("");
  const handleClick = (idx) => {
    setSelected(idx);
  };
  return (
    <div className="question-main">
      <div className="title d-flex flex-row">
        <div className="number mr-3">{question.id}</div>
        <div className="name"> {question.name}</div>
      </div>
      <div className="options">
        {options.map((x, index) => {
          if (!x) return;
          return (
            <QuestionOption
              content={x}
              handleClick={handleClick}
              selected={selected}
              index={index}
              key={index}
            ></QuestionOption>
          );
        })}
      </div>
    </div>
  );
};

export default Question;
