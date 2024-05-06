
import AddTimerButton from './components/AddTimerButton'
import Timer from './components/Timer'
import TimerAskDelete from './components/TimerAskDelete'
import TimerCompleted from './components/TimerCompleted'
import TimerEditBad from './components/TimerEditBad'
import TimerEditGood from './components/TimerEditGood'
import TimerRunning from './components/TimerRunning'
import TimerRunningHover from './components/TimerRunningHover'
import TimerRunningPaused from './components/TimerRunningPaused'

function App() {

  return (
    <>
      <div className="p-8 bg-bg min-h-screen flex justify-center">
            <div className="w-full">
                <div className="grid grid-cols-[repeat(auto-fit,minmax(350px,1fr))] gap-8">
                    <Timer name={"Ramen"} timeLimit={"3 min"} bgColor="bg-sky-500" />
                    <TimerAskDelete name={"Ramen"} timeLimit={"3 min"} bgColor="bg-sky-500" />
                    <TimerRunning name={"Ramen"} timeLimit={"3.5 min"} bgColor="bg-sky-500" />
                    <TimerRunningHover name={"Rice"} timeLimit={"12 min"} bgColor="bg-red-600" />
                    <TimerRunningPaused name={"Rice"} timeLimit={"12 min"} bgColor="bg-red-600" />
                    <TimerCompleted name={"Ramen g Ramen"} timeLimit={"3 min"} bgColor="bg-sky-500" />
                    <TimerEditGood name={"Nap"} timeLimit={"45 min"} bgColor="bg-sky-500" />
                    <TimerEditBad name={"Nap"} timeLimit={"45 min"} bgColor="bg-sky-500" />
                    <AddTimerButton />
                </div>
            </div>
        </div>
    </>
  )
}

export default App
