import { configureStore, applyMiddleware } from '@reduxjs/toolkit'
import chartReducer from './ chartSlice'
import thunk from 'redux-thunk'; 

const rootreducer = ({
  chart: chartReducer
})

export default configureStore({
  reducer: rootreducer,
  middleware: [thunk]
});