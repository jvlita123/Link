import React, { useRef, useState, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import Button from '../utility/Button'

function BannerText(props) {
  return (
    <div className='content-banner'>
      <p className='banner-subtitle'>Because you deserve better!</p>
      <h1 className='banner-text'>
        Get noticed for <span>who</span><br />
        you are.
      </h1>
      <p className='banner-paragraph'>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam nibh nisi, finibus id odio mattis, pharetra dictum massa. Sed vitae orci in urna porttitor eleifend. Etiam maximus neque est, quis porta nunc consequat nec. In imperdiet viverra dui, at ornare.
      </p>
    </div>
  )
}

function Stats() {
  return (
    <div className='stats-wrapper'>
      <div className='stats-card'>
        <h2>15k+</h2>
        <p className='text-dimmed'>Dates and matches made everyday</p>
      </div>
      <div className='stats-card'>
        <h2 className='text-accent'>1,456</h2>
        <p className='text-dimmed'>New members sign up everyday</p>
      </div>
      <div className='stats-card'>
        <h2>1M+</h2>
        <p className='text-dimmed'>Active members from around the world</p>
      </div>
    </div>
  )
}

function BannerInput() {
  const navigate = useNavigate()
  const emailInput = useRef()
  const [focus, setFocus] = useState(false)

  const handleSubmit = () => {
    const params = new URLSearchParams({ email: emailInput.current.value })
    navigate('/signup?' + params)
  }

  useEffect(() => {
    if (focus) {
      emailInput.current.focus()
    }
  }, [focus])

  return (
    <div onClick={() => setFocus(true)} className={focus ? 'input-wrapper focus' : 'input-wrapper'}>
      <i className="bi bi-envelope-at"></i>
      <input onFocus={() => setFocus(true)} onBlur={() => setFocus(false)} ref={emailInput} type='text' placeholder='Enter your email' />
      <Button text='Get started' action={handleSubmit} className='primary capsule' />
    </div>
  )
}

function Capsule(props) {
  const { icon, type } = props

  return (
    <span className={`capsule-icon ${type}`}>
      <i className={icon}></i>
    </span>
  )
}

function BannerImage() {
  return (
    <div className='banner-image'>
      <div className='capsule-icons-wrapper'>
        <Capsule icon='bi bi-cup-straw' type='gray' />
        <Capsule icon='bi bi-hand-thumbs-up' type='gray' />
        <Capsule icon='bi bi-suit-heart' type='accent' />
        <Capsule icon='bi bi-emoji-sunglasses' type='accent' />
      </div>
      <img src='images/banner-image.png' alt='Banner' />
    </div>
  )
}

function Home() {
  return (
    <div className='content home'>
      <BannerText />
      <div className='action'>
        <BannerInput />
      </div>
      <BannerImage />
      <Stats />
    </div>
  )
}

export default Home