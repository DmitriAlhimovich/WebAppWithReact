import React, { Component } from 'react';

export class Employees extends Component {
    static displayName = Employees.name;

  constructor(props) {
    super(props);
      this.state = { _employees: [], loading: true };
      this.handleDeleteRow = this.handleDeleteRow.bind(this);
  }

    handleDeleteRow(i) {
        let rows = [...this.state.rows]
        rows.splice(i, 1)
        this.setState({
            rows: rows
        })
    }

    handleRemove (i) {
    var that = this;
     _.forEach(this.state, function (val, colName) {
        that.state[colName].splice(i, 1); // BUG???
        //_.pullAt(that.state[key], i); // doesn't work either
    });
    console.log(this.state);
    this.setState(this.state);

},

  componentDidMount() {
    this.currentListEmployees();
  }

    static renderEmployeesTable(_employees) {
    return (
        <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr class="table-danger">
             <th>FIO</th>
             <th>Gender</th>
             <th>DateOfBirth</th>
             <th>Department</th>
             <th>Post</th>
             <th>Room</th>
             <th>Phone</th>
             <th>Email</th>
             <th></th>
             <th></th>
          </tr>
        </thead>
        <tbody>
          {_employees.map(employee =>
              <tr key={employee.fio}>
                  <td>{employee.fio}</td>
                  <td>{employee.gender}</td>
                  <td>{employee.dateOfBirth}</td>
                  <td>{employee.department}</td>
                  <td>{employee.post}</td>
                  <td>{employee.room}</td>
                  <td>{employee.phone}</td>
                  <td>{employee.email}</td>
                  <td>
                      <button onClick={this.handleRemove.bind(this, )}>Remove</button>
                  </td>
              </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : Employees.renderEmployeesTable(this.state._employees);

    return (
      <div>
            <h1 id="tabelLabel" >Current Employees</h1>
            <p>This component demonstrates Current Employees from the server.</p>
        {contents}
      </div>
    );
  }

  async currentListEmployees() {
    const response = await fetch('employees');
    const data = await response.json();
    this.setState({ _employees: data, loading: false });
  }
}
