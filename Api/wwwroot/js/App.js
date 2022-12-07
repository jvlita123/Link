// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Write your JavaScript code.
var e = React.createElement;

class App extends React.Component {
  constructor(props) {
      super(props)
      this.state = {
          count: 0
      }
  }

  render() {
      return (
          <div>App {this.state.count}</div>
      )
  }
}
