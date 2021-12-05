import { createSlice } from '@reduxjs/toolkit'

export const chartSlice = createSlice({
    name: 'chart',
    initialState: {
        value: []
    },
    reducers: {
        getData: (state, action) => {
            state.value = action.payload;
            console.log(action.payload)
          },
    }
})

export const {getData} = chartSlice.actions

export default chartSlice.reducer