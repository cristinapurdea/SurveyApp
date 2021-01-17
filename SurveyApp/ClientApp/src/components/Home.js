import React, { Component } from 'react';
import { NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello, world!</h1>
        <p>Welcome to this survey app built with C# and React!</p>
        <p>
            To see the survey, please click below:
            <NavLink tag={Link} className="text-dark" to="/fetch-survey">See survey</NavLink>   
        </p>
      </div>
    );
  }
}
