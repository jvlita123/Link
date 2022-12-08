class NavLink extends React.Component {

    constructor(props) {
        super(props)
    }

    render() {
        return (
            <a href={this.props.toUrl} className="nav-link"><li className="nav-item">{this.props.title}</li></a>
        )
    }
}

const navLinks = [
    {
        title: 'Love',
        toUrl: '/'
    },
    {
        title: 'Just chat',
        toUrl: '/'
    },
    {
        title: 'Friendzone',
        toUrl: '/'
    }
]

class Navbar extends React.Component {

    constructor(props) {
        super(props)
    }

    render() {
        return (
            <nav>
                <div className="logo">
                    <h2>Link</h2>
                </div>
                <div className="nav-links">
                    <ul>
                        {navLinks.map((navElement, key) => 
                            <NavLink key={key} title={navElement.title} toUrl={navElement.toUrl} /> 
                        )}
                    </ul>
                </div>
                <div className="nav-auth">
                    <Button title={'Sign Up'} buttonType={'primary'} actionHandler={() => console.log('Sign Up')} />
                    <Button title={'Log In'} buttonType={'outline-primary'} actionHandler={() => console.log('Log In')} />
                    <a className="nav-link"><li className="nav-item">My profile</li></a>
                </div>
            </nav>
        )
    }
}
