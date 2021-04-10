import React, { useRef, useState, useEffect } from "react";
import PropTypes from "prop-types";

const FilterForm = (props) => {
  const { onSubmit } = props;
  const [formFilter, setFormFilter] = useState("");
  const typingTimeoutRef = useRef(null);
  const testRef = useRef(1);
  var testRefCon = 1;
  console.log(testRefCon);
  testRef.current++;
  console.log(testRef.current);
  const handleOnChange = (e) => {
    const value = e.target.value;
    setFormFilter(value);
    if (typingTimeoutRef.current) {
      clearTimeout(typingTimeoutRef.current);
    }
    typingTimeoutRef.current = setTimeout(() => {
      const formValue = {
        filter: e.target.value,
      };
      onSubmit(formValue);
    }, 300);
  };
  return (
    <form
      onSubmit={(e) => {
        e.preventDefault();
        setFormFilter("");
      }}
    >
      <input type="text" onChange={handleOnChange} value={formFilter} />
    </form>
  );
};

FilterForm.propTypes = {};

export default FilterForm;
