import React, { Component } from 'react';

import { makeStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';

export class Employees extends Component {
    static displayName = Employees.name;

    constructor(props) {
        super(props);
        this.state = { employees: [], loading: true, searchedValue: '' };
        this.onRemoveEmployee = this.onRemoveEmployee.bind(this);
        this.onSearch = this.onSearch.bind(this);
        this.onEdit = this.onEdit.bind(this);
        //this.onAddEmployee = this.onAddEmployee.bind(this);
    }

    async currentListEmployees() {
        const response = await fetch('employees');
        const data = await response.json();
        this.setState({ employees: data, loading: false });
    }
    
    onRemoveEmployee(event) {

        let id = event.currentTarget.value;
        fetch('employees/' + id,
            {
                method: 'delete',
                headers: {
                    'Accept': 'application/json, text/plain, */*',
                    'Content-Type': 'application/json'
                }

            }).then(res => res.json()).then(res => console.log(res));

        let newEmployees = this.state.employees.filter(e => e.id !== id);
        this.setState({ employees: newEmployees });
    }


    onSearch = (event) => {
        this.setState({ searchedValue: event.target.value });
    }

    onEdit = (event) => {
        let id = event.currentTarget.value;
        this.props.history.push('editemployee/id=' + id);
    }

    //onAddEmployee = (event) => {
    //    fetch('employees/addemployee',
    //        {
    //            method: 'post',
    //            headers: {
    //                'Accept': 'application/json, text/plain, */*',
    //                'Content-Type': 'application/json'
    //            }

    //        }).then(res => res.json()).then(res => console.log(res));

    //    //let addEmployees = _response.json();
    //    //this.setState({ employees: addEmployees, loading: false });
    //}

    componentDidMount() {
        this.currentListEmployees();
    }

    renderEmployeesTable(employees, onRemove, onSearch, onEdit) {

        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
            <input type="text" placeholder="search" onChange={onSearch} value={this.state.searchedValue} />
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
                    {employees.map(employee =>
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
                                <Button variant="outlined" value={employee.id} onClick={onRemove}>Remove</Button>
                            </td>
                            <td>
                                <Button variant="outlined" value={employee.id} onClick={onEdit}>Edit</Button>
                            </td>
                        </tr>
                    )}
                </tbody>                
            </table>
        );
    }

    render() {
        
         let newEmployees = this.state.employees.filter((item) => item.fio.includes(this.state.searchedValue));
         let contents = this.state.loading
            ? <p><em>Loading...</em></p>
             : this.renderEmployeesTable(newEmployees, this.onRemoveEmployee, this.onSearch, this.onEdit);

        return (
            <div>
                <h1 id="tabelLabel">Current Employees</h1>
                <p>This component demonstrates Current Employees from the server.</p>
                {/*<p><button value={null} onClick={this.onAddEmployee}>AddEmployee</button></p>*/}
                <p><a href="addemployee">AddEmployee</a></p>
         
                {contents}
            </div>
        );
    }


}
