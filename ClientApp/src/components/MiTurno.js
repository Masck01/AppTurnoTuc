import React, { Component, useState } from "react";
import {
  Card,
  CardBody,
  Container,
  Row,
  Col,
  CardTitle,
  Alert,
  Badge,
  Jumbotron
} from "reactstrap";
import authService from "./api-authorization/AuthorizeService";

export default class MiTurno extends Component {
  static displayName = MiTurno.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderForecastsTable(forecasts) {
    return (
      <Container>
        
        {forecasts.map(forecast => (
          <Row>
            <Col>
              <Card className="mb-3" style={{ borderColor: "#47BBC2" }}>
                <CardBody style={{ background: "#47BBC2" }}>
                  <CardTitle color="success">
                    <Alert
                      color={forecast.estado == "Activo" ? "success" : "danger"}
                    >
                      {forecast.estado}
                    </Alert>
                  </CardTitle>
                  <Jumbotron fluid>
                    
                    <h3 className="text-center">
                      Numero de Turno: {forecast.numero}
                    </h3>
                    <h3 className="text-center">
                      Identificador: {forecast.turnoID}
                    </h3>
                    <h3 className="text-center">
                      Fecha y Hora de Emision: {forecast.fecha}
                    </h3>
                  </Jumbotron>
                </CardBody>
              </Card>
            </Col>
          </Row>
        ))}
      </Container>
    );
  }

  render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      MiTurno.renderForecastsTable(this.state.forecasts)
    );

    return (
      <div>
        <h1 className="text-center">Listado de turnos</h1>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const token = await authService.getAccessToken();
    const response = await fetch("turnos", {
      headers: !token ? {} : { Authorization: `Bearer ${token}` }
    });
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
    console.log(this.state.forecasts);
  }
}
