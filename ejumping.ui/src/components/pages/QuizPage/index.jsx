import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { loadQuestionRequest } from "../../actions/quizActions";
import Question from "./Question/Question";
import "./QuizPage.scss";
const QuizPage = () => {
  const dispatch = useDispatch();
  // const data = useSelector((state) => state.quiz.questions);
  const data = { ...mock };
  const totalPage = data.totalCount / data.pageSize;
  const finished = (data.page / totalPage) * 100;

  useEffect(() => {
    dispatch(loadQuestionRequest(1, 1, 1, 6));
  }, []);
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
                Page <b>{data.page}</b> of {totalPage}
              </div>
              <div className="loading-bar">
                <div className="loaded" style={{ width: `${finished}%` }}></div>
              </div>
            </div>
          </div>
          <div className="questions-container">
            {data.items.map((question, index) => (
              <Question question={question} key={question.id} />
            ))}
          </div>
        </div>
      </div>
    </div>
  );
};
const mock = {
  page: 1,
  pageSize: 5,
  totalCount: 20,
  items: [
    {
      id: 1,
      name: "Can I park here?",
      firstOption: "Sorry, I did that.",
      secondOption: "It's the same place.",
      thirdOption: "Only for half an hour.",
      fouthOption: null,
    },
    {
      id: 2,
      name: "Can I park here?",
      firstOption: "Sorry, I did that.",
      secondOption: "It's the same place.",
      thirdOption: "Only for half an hour.",
      fouthOption: null,
    },
    {
      id: 3,
      name: "Can I park here?",
      firstOption: "Sorry, I did that.",
      secondOption: "It's the same place.",
      thirdOption: "Only for half an hour.",
      fouthOption: null,
    },
    {
      id: 4,
      name: "Can I park here?",
      firstOption: "Sorry, I did that.",
      secondOption: "It's the same place.",
      thirdOption: "Only for half an hour.",
      fouthOption: "It's OK",
    },
    {
      id: 5,
      name: "Can I park here?",
      firstOption: "Sorry, I did that.",
      secondOption: "It's the same place.",
      thirdOption: "Only for half an hour.",
      fouthOption: null,
    },
  ],
};

export default QuizPage;
