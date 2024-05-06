import { faPenToSquare, faTrashCan } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import TimerTitle from "./subcomponents/TimerTitle";

type timerProps = {
    name: string;
    timeLimit: string;
    bgColor: string;
    askDelete?: boolean;
};

export default function Timer({}: timerProps) {
    return (
        <div className="timer-wrapper bg-neutral-400">
            <TimerTitle name={"Ramen"} timeLimit={"3 min"} />
            <div className="timer-content-wrapper">
                <button className="medium-round-button hover:bg-neutral-300 fade">
                    <FontAwesomeIcon
                        className="mx-auto my-auto text-3xl"
                        icon={faPenToSquare}
                    />
                </button>
                <button className="big-round-button hover:bg-neutral-300 fade">
                    <i className="fa-solid fa-play text-6xl translate-x-[3px]"></i>
                </button>
                <button className="medium-round-button hover:bg-neutral-300 fade">
                    <FontAwesomeIcon
                        className="mx-auto my-auto text-3xl"
                        icon={faTrashCan}
                    />
                </button>
            </div>
        </div>
    );
}
