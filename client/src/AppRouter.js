import React from 'react'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import { routes } from './constants/routes'
import Navbar from './utility/Navbar'

function AppRouter() {
  return (
    <>
      <BrowserRouter>
        <Navbar />
        <Routes>
          {routes.map((route, key) =>
            <Route key={key} path={route.path} element={route.component} />
          )}
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default AppRouter