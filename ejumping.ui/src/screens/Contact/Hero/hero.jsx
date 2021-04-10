import React from "react";

const Hero = (props) => {
  const { name } = props;
  console.log(name);
  return <div>{name}</div>;
};

export default React.memo(Hero);
