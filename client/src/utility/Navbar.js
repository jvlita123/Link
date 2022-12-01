import React from 'react'
import { NavLink, useNavigate } from 'react-router-dom'
import Button from './Button'

function Navbar() {
    const navigate = useNavigate()

    return (
        <nav className='navbar'>
            <div className='flex-wrapper navbar-space-fillout'>
                <Button text='Log In' action={() => {}} />
                <Button text='Register' action={() => {}} className='primary capsule' />
                <h2 className='logo'>Link</h2>
            </div>
            <ul className='navbar-link-list'>
                <NavLink className='nav-link' to='/'><li>Home</li></NavLink>
                <NavLink className='nav-link' to='/about'><li>Loose writing</li></NavLink>
                <NavLink className='nav-link' to='/privacy'><li>Friendship</li></NavLink>
                <NavLink className='nav-link' to='/contact'><li>Love</li></NavLink>
            </ul>
            <div className='flex-wrapper'>
                <Button text='Log In' action={() => navigate('/login')} />
                <Button text='Register' action={() => navigate('/signup')} className='primary capsule' />
            </div>
        </nav>
    )
}

export default Navbar