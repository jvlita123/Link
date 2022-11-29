import Home from '../components/Home'
import Login from '../components/Login'
import PageNotFound from '../components/PageNotFound'
import Register from '../components/Register'

export const routes = [
    {
        path: '/',
        component: <Home />
    },
    {
        path: '/login',
        component: <Login />
    },
    {
        path: '/signup',
        component: <Register />
    },
    {
        path: '*',
        component: <PageNotFound />
    },
]