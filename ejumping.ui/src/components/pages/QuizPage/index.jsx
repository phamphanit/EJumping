import React from "react";
import Question from "./Question/Question";
import "./QuizPage.scss";
const QuizPage = () => {
  return (
    <div className="quiz-main">
      <div className="container">
        <div className="navigation">
          Cambridge EnglishTest -- Test your English -- General English
        </div>
        <div className="quiz-header">
          <h1>General English</h1>
        </div>
        <div className="test-container">
          <div className="test-header">
            <div className="test-title">Test your English</div>
            <div className="requirement">
              For the questions below, please choose the best option to complete
              the sentence or conversation
            </div>
            <div className="loading-test">
              <div className="count">
                Page <b>1</b> of 5
              </div>
              <div className="loading-bar">
                <div className="loaded"></div>
              </div>
            </div>
          </div>
          <div className="questions-container">
            <Question></Question>
            <Question></Question>
            <Question></Question>
          </div>
        </div>
      </div>
    </div>
  );
};

export default QuizPage;
