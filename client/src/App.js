import React, { useEffect } from 'react'

function App() {

  useEffect(() => {
    fetch('/', {
      method: 'GET'
    }).then(response => console.log(response))
  })

  return (
    <div className="App">
      <header className="App-header">
        Hello React Client
      </header>
    </div>
  )
}

export default App
