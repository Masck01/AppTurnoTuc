import React, { useState } from "react";

// Componentes
import { Jumbotron, Tooltip } from "reactstrap";

const Footer = () => {
  const [toolTipOpen, setToolTipOpen] = useState(false);
  
  const toogle = () => setToolTipOpen(!toolTipOpen);
  

  return (
    <Jumbotron>
      <div className="container">
        <div className="row">
          <div className="col l6 s12">
            <h5 className="white-text">Acerca de nosotros</h5>
            <p className="grey-text text-lighten-4">
                We are a team of University UTN-FRT, working on this project. Final Project subject.
                We hope our professors likes this web it will be greatly appreciated.
            </p>
          </div>
        </div>
      </div>
      <div className="footer-copyright">
        <div className="container">
          <p>
              Made by{" "}
              <span href="#" id="tooltipe" style={{textDecoration:"underline",color:"#7e86a1"}}>
                End Game
              </span>
          </p>
          <Tooltip target="tooltipe" placement="right" isOpen={toolTipOpen} toggle={toogle}>
              End Game
          </Tooltip>
        </div>
        <div>
    </div>

        
      </div>
    </Jumbotron>
  );
};

export default Footer;
