import React from 'react'
import { Navbar, Nav } from 'react-bootstrap'

const Header = () => (
  <Navbar bg="primary" variant="dark">
    <Navbar.Brand href="#home">Títulos em Atraso</Navbar.Brand>
    <Nav className="mr-auto">
      <Nav.Link href="/">Adicionar Título</Nav.Link>
      <Nav.Link href="/Listagem">Listar Títulos</Nav.Link>
    </Nav>
  </Navbar>
);

export default Header;
