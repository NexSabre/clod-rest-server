using System;
using System.IO.MemoryMappedFiles;


namespace clod_rest_server
{
    public class GameCommunications
    {
        private MemoryMappedFile m_MemoryMappedFile;
        private MemoryMappedViewAccessor m_MemoryMappedViewAccessor;
        public enum ParameterTypes
        {
            Nil,
            M_Random,
            M_Shake,
            M_CabinDamage,
            M_CabinState,
            M_NamedDamage,
            M_SystemWear,
            M_Health,
            C_Steering,
            C_Brake,
            C_Throttle,
            C_Trigger,
            C_Pitch,
            C_Mix,
            C_WaterRadiator,
            C_OilRadiator,
            C_RadiatorAutomation,
            C_PitchAutomation,
            C_Compressor,
            C_Afterburner,
            C_BoostEnabler,
            C_SlowRunningCutOut,
            C_Magneto,
            C_Feather,
            C_CarbHeater,
            C_HatchDoor,
            C_HatchJettison,
            C_Timer,
            C_Timer1,
            C_Aileron,
            C_Elevator,
            C_Rudder,
            C_AileronTrim,
            C_ElevatorTrim,
            C_RudderTrim,
            C_TailwheelLock,
            C_LandingFlap,
            C_LeadingEdgeSlats,
            C_Undercarriage,
            C_UndercarriageEmergency,
            C_BombBayDoor,
            C_Airbrake,
            C_FuelTankSelector,
            C_TelepirometroElettrico,
            C_AltimeterPinion,
            C_AnemometroPinion,
            C_BombSight,
            C_Sight,
            C_Bombenabwurfgerat,
            C_KraftstoffSelector,
            C_LiquidGauge0,
            C_LiquidGauge1,
            C_PriLights,
            C_SecLights,
            C_SightLights,
            C_PitotHeater,
            C_Handpumpe,
            C_RadTXRX,
            C_RadPriNav,
            C_RadSecNav,
            C_Kurssteuerung,
            A_Steering,
            A_Brake,
            A_Aileron,
            A_Elevator,
            A_Rudder,
            A_AileronTrim,
            A_ElevatorTrim,
            A_RudderTrim,
            A_Undercarriage,
            A_UndercarriageShock,
            A_UndercarriageWheel,
            A_HatchDoor,
            A_BombBayDoor,
            A_ImpellerAngle,
            A_ImpellerAngularVelocity,
            A_ImpellerUnfold,
            A_LandingFlap,
            A_Airbrake,
            A_EngineAirRadiator,
            A_EngineWaterRadiator,
            A_EngineOilRadiator,
            A_LeadingEdgeSlat,
            Z_Coordinates,
            Z_Orientation,
            Z_Overload,
            Z_AltitudeAGL,
            Z_AltitudeMSL,
            Z_VelocityIAS,
            Z_VelocityTAS,
            Z_VelocityMach,
            Z_AmbientAirTemperature,
            S_ElectricVoltage,
            S_ElectricIncandescingRatio,
            S_ElectricAmperage,
            S_ElectricPrimaryPitLight,
            S_ElectricSecondaryPitLight,
            S_ElectricSightLight,
            S_FuelReserve,
            S_HatchDoor,
            S_UndercarriageValve,
            S_PneumoContainerPressure,
            S_PneumoLinePressure,
            S_HydroPressure,
            S_HydroReserve,
            S_Sturzanlage,
            S_GunOperation,
            S_GunReserve,
            S_GunClipReserve,
            S_BombReserve,
            S_Fenster,
            S_PitotHeater,
            S_Bombenabwurfgerat,
            S_Turret,
            M_Reserved000,
            M_Reserved001,
            M_Reserved002,
            M_Reserved003,
            M_Reserved004,
            M_Reserved005,
            M_Reserved006,
            M_Reserved007,
            M_Reserved008,
            M_Reserved009,
            M_Reserved00A,
            M_Reserved00B,
            M_Reserved00C,
            M_Reserved00D,
            M_Reserved00E,
            M_Reserved00F,
            M_Reserved010,
            M_Reserved011,
            M_Reserved012,
            M_Reserved013,
            M_Reserved014,
            M_Reserved015,
            M_Reserved016,
            M_Reserved017,
            M_Reserved018,
            M_Reserved019,
            M_Reserved01A,
            M_Reserved01B,
            M_Reserved01C,
            M_Reserved01D,
            M_Reserved01E,
            M_Reserved01F,
            I_Timer,
            I_AmbientTemp,
            I_EngineRPM,
            I_EngineManPress,
            I_EngineBoostPress,
            I_EngineWatPress,
            I_EngineOilPress,
            I_EngineFuelPress,
            I_EngineWatTemp,
            I_EngineRadTemp,
            I_EngineOilTemp,
            I_EngineOilRadiatorTemp,
            I_EngineTemperature,
            I_EngineCarbTemp,
            I_Pitch,
            I_VelocityIAS,
            I_Altitude,
            I_Variometer,
            I_Slip,
            I_MagneticCompass,
            I_RepeaterCompass,
            I_Peilzeiger,
            I_FuelReserve,
            I_LiquidReserve,
            I_Voltamperemeter,
            I_Voltmeter,
            I_Amperemeter,
            I_HydroPressure,
            I_HydroEmPressure,
            I_Turn,
            I_AH,
            I_DirectionIndicator,
            I_SlavedCompass,
            I_Suction,
            I_AFN,
            I_ADF,
            I_RDF,
            I_RMI,
            I_FLRC,
            I_Kurssteuerung,
            I_BombSight
        }

        public GameCommunications()
        {
            m_MemoryMappedFile = null;
            m_MemoryMappedViewAccessor = null;
        }

        private void OpenMMF()
        {
            try
            {
                m_MemoryMappedFile = MemoryMappedFile.OpenExisting("CLODDeviceLink", MemoryMappedFileRights.Read);
                m_MemoryMappedViewAccessor = m_MemoryMappedFile.CreateViewAccessor(0, 10000 * sizeof(double), MemoryMappedFileAccess.Read);
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return;
            }
        }

        public double? GetParameter(int ParameterType, int SubType)
        {
            if (m_MemoryMappedFile == null)
                OpenMMF();

            try
            {
                return m_MemoryMappedViewAccessor.ReadDouble((((int)ParameterType * 10) + SubType) * sizeof(double));
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return null;
            }
        }
    }
}
