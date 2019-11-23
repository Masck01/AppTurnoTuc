import React, { Component   } from "react";

// Componentes

import {
  Button,
  Card,
  CardBody,
  CardImg,
  CardHeader,
  CardFooter,
  Col,
  Row,
  Container,
  NavLink
} from "reactstrap";

import { Link } from "react-router-dom";

// Flare
import FlareComponent from "flare-react";

import Earth from "../assets/Earth.flr";

import authService from "./api-authorization/AuthorizeService";

export default class Turno extends Component {
  static displayName = Turno.name;

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
          <Card className="mb-3">
            <CardHeader style={{ background: "#7CD5D6" }}>
              <Row>
                <Col sm="12" md={{ size: 4, offset: 4 }}>
                  <h1 className="text-center" style={{ color: "#000" }}>
                    {forecast.tipoAtencion}
                  </h1>
                </Col>
              </Row>
            </CardHeader>
            <CardImg></CardImg>
            <CardBody style={{ background: "#313131" }}>
              <Row>
                <Col md={{ size: 4, offset: 4 }}>
                  <FlareComponent
                    width={350}
                    height={300}
                    animationName={"Preview2"}
                    file={Earth}
                  />
                </Col>
              </Row>
            </CardBody>
            <CardFooter style={{ background: "#7CD5D6" }}>
              <Button outline color="success" size="lg" block>
                <NavLink tag={Link} to="/miturno">
                  <h3>Solicitar Turno</h3>
                </NavLink>
              </Button>
            </CardFooter>
          </Card>
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
      Turno.renderForecastsTable(this.state.forecasts)
    );

    return (
      <div>
        <h1 className="text-center">Lineas de atencion</h1>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const token = await authService.getAccessToken();
    const response = await fetch("atencions", {
      headers: !token ? {} : { Authorization: `Bearer ${token}` }
    });
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
    console.log(this.state.forecasts);
  }
}
