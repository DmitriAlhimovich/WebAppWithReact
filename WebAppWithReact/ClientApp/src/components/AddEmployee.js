import React, { Component } from 'react';
//import createBrowserHistory from 'history/createBrowserHistory';

//const history = createBrowserHistory({ forceRefresh: true });

export class AddEmployee extends Component {
    static displayName = AddEmployee.name;

    constructor(props) {
        super(props);
        this.state = { fio: '', gender: '', dateOfBirth: '', department: '', post: '', room: '', phone: '', email: '' };

        this.onChangeFio = this.onChangeFio.bind(this);
        this.onChangeGender = this.onChangeGender.bind(this);
        this.onChangeDateOfBirth = this.onChangeDateOfBirth.bind(this);
        this.onChangeDepartment = this.onChangeDepartment.bind(this);
        this.onChangePost = this.onChangePost.bind(this);
        this.onChangeRoom = this.onChangeRoom.bind(this);
        this.onChangePhone = this.onChangePhone.bind(this);
        this.onChangeEmail = this.onChangeEmail.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
    }

    onSubmit(event) {
        //alert(`${this.state.fio}, добро пожаловать!`);
        //let fio = event.target.value.fio;
                
        fetch('employees/addemployee/',
            {
                method: 'post',
                headers: {
                    'Accept': 'application/json, text/plain, */*',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    firstName: this.state.fio,
                    department: this.state.department
                })

            });//.then(res => history.push('/employees')).then(res => console.log(res));
        
        event.preventDefault();
        this.props.history.push('/employees');
    }

    onChangeFio(event) {
        this.setState({ fio: event.target.value });
    }

    onChangeGender(event) {
        this.setState({ gender: event.target.value });
    }

    onChangeDateOfBirth(event) {
        this.setState({ dateOfBirth: event.target.value });
    }

    onChangeDepartment(event) {
        this.setState({ department: event.target.value });
    }

    onChangePost(event) {
        this.setState({ post: event.target.value });
    }

    onChangeRoom(event) {
        this.setState({ room: event.target.value });
    }

    onChangeEmail(event) {
        this.setState({ email: event.target.value });
    }

    //onChangeEmail(event) {
    //    let userEmail = event.target.value;
    //    (userEmail.match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/))
    //        ? this.setState({ email: userEmail }) : this.setState({ email: "" });
    //}

    onChangePhone(event) {
        this.setState({ phone: event.target.value });
    }

    render() {
        return (
            <form onSubmit={this.onSubmit}>
                <p><label> FIO: <input type="text" name="fio" value={this.state.fio}
                    onChange={this.onChangeFio} /></label></p>
                <p><label> Gender: <input type="text" name="gender" value={this.state.gender}
                    onChange={this.onChangeGender} /></label></p>
                <p><label> DateOfBirth: <input type="text" name="dateOfBirth" value={this.state.dateOfBirth}
                    onChange={this.onChangeDateOfBirth} /></label></p>
                <p><label> Department: <input type="text" name="department" value={this.state.department}
                    onChange={this.onChangeDepartment} /></label></p>
                <p><label> Post: <input type="text" name="post" value={this.state.post}
                    onChange={this.onChangePost} /></label></p>
                <p><label> Room: <input type="text" name="room" value={this.state.room}
                    onChange={this.onChangeRoom} /></label></p>
                <p><label> Phone: <input type="text" name="phine" value={this.state.phone}
                    onChange={this.onChangePhone} /></label></p>
                <p><label> Email: <input type="text" name="email" value={this.state.email}
                    onChange={this.onChangeEmail} /></label></p>
                <p><input type="submit" value="Submit" /></p>
            </form>
        );
    }
}