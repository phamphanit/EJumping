import React, { useState } from "react";
import "./Carousel.scss";

import { FaArrowAltCircleRight, FaArrowAltCircleLeft } from "react-icons/fa";
const Carousel = ({ slides }) => {
  const [current, setCurrent] = useState(0);
  const length = slides.length;

  // useEffect(() => {
  //   const intervalSlide = setInterval(() => {
  //     currentIndex.current =
  //       currentIndex.current === length - 1 ? 0 : currentIndex.current + 1;
  //     setCurrent(currentIndex.current);
  //   }, 10000);
  //   return () => clearInterval(intervalSlide);
  // }, []);
  const nextSlide = () => {
    setCurrent(current === length - 1 ? 0 : current + 1);
  };
  const prevSlide = () => {
    setCurrent(current === 0 ? length - 1 : current - 1);
  };
  if (!Array.isArray(slides) || slides.length <= 0) {
    return null;
  }

  return (
    <div className="slider">
      <FaArrowAltCircleLeft className="arrow ar-left" onClick={prevSlide} />
      <FaArrowAltCircleRight className="arrow ar-right" onClick={nextSlide} />
      {slides.map((slide, index) => (
        <div
          className={
            index === current
              ? "slide active"
              : index === current - 1
              ? "slide prev"
              : index === current + 1
              ? "slide next"
              : index === 0
              ? "slide first"
              : index === length - 1
              ? "slide last"
              : "slide "
          }
          key={index}
        >
          {index === current && (
            <img src={slide.imageUrl} alt="Carousel" className="image"></img>
          )}
        </div>
      ))}
      <ul className="carousel-point">
        {slides.map((slide, index) => (
          <li
            className={index === current ? "active" : ""}
            key={index}
            onClick={() => setCurrent(index)}
          ></li>
        ))}
      </ul>
    </div>
  );
};

export default Carousel;
