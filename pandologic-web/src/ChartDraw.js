import React from 'react'
import { useSelector } from 'react-redux'
import Chart from "react-google-charts";


export default function ChartDraw() {
    var chartData = useSelector((state) => state.chart.value)
    var charDataStructure = [[{ type: 'date', label: 'Day' }, "Job Views", "Predicted job views", "Active jobs"]]

    for(let i = 0; i < chartData.length ; i += 1) {
      charDataStructure.push([new Date(chartData[i].date), chartData[i].totalViews, chartData[i].cumulativePredicted, chartData[i].activeJobs])
    }


    return(
        <div>
            <div>
            {
              chartData.length > 0 ?
                <Chart
                width={'100%'}
                height={'500'}
                chartType="ComboChart"
                loader={<div>Loading Chart</div>}
                data={charDataStructure}
                options={{
                  title:
                  'Cumulative jobs views vs.',
                  tooltip: {isHtml: true},
                  width: '100%',
                  height: 500,
                  vAxis: { title: 'Job View' },
                  seriesType: 'line',
                  series: { 
                    1: {pointSize: 10},
                    2: { type: 'bars' },
                 },
                  pointSize: 5,

                }}
                rootProps={{ 'data-testid': '4' }}
              />
              :
              <div></div>
            }
            </div>
        </div>
    )
}

