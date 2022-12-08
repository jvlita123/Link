class Button extends React.Component {

    constructor(props) {
        super(props)
    }

    render() {
        return (
            <button className={'button ' + this.props.buttonType} onClick={this.props.actionHandler}>
                {this.props.title}
            </button>
        )
    }
}
