import React from 'react'
import Team from './Team'

interface Props  {}

const TeamList = (props: Props) => {
  return (
    <Team teamName="Red Team" teamUrl="Urltest" teamScore= {33} />
  )
}

export default TeamList