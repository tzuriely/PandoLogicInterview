import React, { useState, useEffect } from 'react'
import { useDispatch } from 'react-redux'
import { getData } from './redux/ chartSlice'

import { DateRangePicker } from 'react-date-range';
import { max } from 'date-fns';

export default function DatesPicker() {
  const dispatch = useDispatch()
  const [selectionRange, setSelectionRange] = useState({
    startDate: new Date(),
    endDate: new Date(),
    key: 'selection',});

  //Get dates range
  useEffect(() =>  {
    console.log("in get range")
    fetch('http://localhost:8081/api/jobs/range')
    .then(res => res.json())
    .then(data => setSelectionRange({
      startDate: new Date(data.startDate),
      endDate: new Date(data.endDate),
      key: 'selection'
    }))}, [])

  //Get Data 
  function handleSelect(ranges) {
    setSelectionRange(ranges.selection)
    let start = new Date(ranges.selection.startDate).toISOString().substring(0, 10);
    let end = new Date(ranges.selection.endDate).toISOString().substring(0, 10);

    fetch(`http://localhost:8081/api/jobs/${start}/${end}`)
    .then(res => res.json())
    .then(obj => dispatch(getData(obj)))
  }
  
  return (
    <DateRangePicker
      showMonthAndYearPickers = {false}
      ranges={[selectionRange]}
      onChange={handleSelect}
      shownDate = {selectionRange.startDate}
      moveRangeOnFirstSelection={false}
    />
  )

}
